using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;

namespace BlackFrameEraser
{
    public partial class MainForm : Form
    {
        // Content item for the combo box
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        // string pathVideo = "";
        string[] files = { };
        int indiceImagen = -1;
        int contadorFrames = 0;

        public MainForm()
        {
            InitializeComponent();
            comboBoxVISION.Items.Add(new Item("PANASONIC", 1));
            comboBoxVISION.Items.Add(new Item("KEYENCE", 2));
        }

        private void btnSeleccionaVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "MPG (*.mpg)|*.mpg|Avi (*.avi)|*.avi|All Files (*.*)|*.*";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = dlg.FileNames;
                if (files.Length > 0)
                    tbVideo.Text = Path.GetDirectoryName(files[0]);
                else
                    tbVideo.Text = "No files";
            }
        }

        private void btnProcesaVideo_Click(object sender, EventArgs e)
        {
            contadorFrames = 0; 
            if ((Item)comboBoxVISION.SelectedItem != null && ((Item)comboBoxVISION.SelectedItem).Value > 0)
            {
                if (((Item)comboBoxVISION.SelectedItem).Value == 1) checkBuenos.Checked = true; //PANASONIC
                if (files.Length > 0)
                {
                    foreach (string pathVideo in files)
                    {
                        if (File.Exists(pathVideo))
                        {
                            LimpiaFrames(pathVideo);
                        }
                        else
                        {
                            MessageBox.Show("No existe el fichero \r\n" + pathVideo);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay ficheros en: \r\n" + tbVideo.Text);
                }
            }
            else { MessageBox.Show("Seleccione sistema de vision"); }
        }

        private void LimpiaFrames(string _path)
        {
            Emgu.CV.Capture videoStream = new Emgu.CV.Capture(_path);
            int videoW = videoStream.Width;
            int videoH = videoStream.Height;
            int videoFps = 30;

            string saveDir = Path.GetDirectoryName(_path);
            string extension = Path.GetExtension(_path);
            string baseName = Path.GetFileName(_path).Replace(extension, "");

            string saveFileName = Path.Combine(saveDir, baseName + "_" + comboBoxVISION.Text + ".avi");

            bool bSigueProcesando = true;

            VideoWriter vw = new VideoWriter(saveFileName, -1, videoFps, new Size(videoW, videoH), true);
            // VideoWriter vw = new VideoWriter(saveFileName, VideoWriter.Fourcc('D', 'I', 'V', 'X'), videoFps, new Size(videoW, videoH), true);

            System.IO.Directory.CreateDirectory(saveDir);

            indiceImagen = -1;
            while (bSigueProcesando)
            {
                try
                {
                    using (Mat frame = videoStream.QueryFrame())
                    {
                        if (frame == null)
                        {
                            bSigueProcesando = false;
                            continue;
                        }

                        //PANASONIC
                        using ( Image<Bgr, byte> imageFrame = frame.Clone().ToImage<Bgr, byte>() )
                        {
                            // SI FRAME ES NEGRO => IGNORAR
                            if (imageFrame.Split()[0].GetSum().Intensity < frame.Height * frame.Height * 50)
                            {
                                continue;
                            }
                            contadorFrames++;
                            // frame.Save(Path.Combine(saveDir, "FRAME_" + baseName + "_" + (++contador) + ".jpg"));
                            vw.Write(frame);
                        }; //The image will be disposed here and memory freed
                    }
                }
                catch (Exception ex)
                {
                    GC.WaitForPendingFinalizers();
                }
            }

            MessageBox.Show("FIN - Video Procesado en: \r\n" + saveFileName);
            vw.Dispose();
            videoStream.Dispose();
        }

        private void ExtraeErrores(string _path)
        {
            Mat frameAnterior = null;

            Emgu.CV.Capture videoStream = new Emgu.CV.Capture(_path);

            string extension = Path.GetExtension(_path);
            string baseName = Path.GetFileName(_path).Replace(extension, "");

            string saveDir = Path.GetDirectoryName(_path);
            System.IO.Directory.CreateDirectory(saveDir);

            bool bSigueProcesando = true;

            indiceImagen = -1;
            int contador = -1;
            double rojo = 0;
            int frameDelay = 2;
            bool salvaFrame = false;

            while (bSigueProcesando)
            {
                try
                {
                    using (Mat frame = videoStream.QueryFrame())
                    {
                        if (frame == null)
                        {
                            bSigueProcesando = false;
                            continue;
                        }
                        if (contador < 0)
                        {
                            frameAnterior = frame.Clone();
                            contador = 0;
                        }

                        if (((Item)comboBoxVISION.SelectedItem).Value == 2)
                        {
                            // KEYENCE
                            Rectangle roi = new Rectangle(frame.Cols / 4, 2 * (frame.Rows / 6), frame.Cols / 4, frame.Rows / 6);
                            Mat roi_VISOK = new Mat(frame, roi);
                            bool isRed = false;

                            using (Image<Bgr, byte> frameOriginal = roi_VISOK.ToImage<Bgr, byte>())
                            {
                                rojo = frameOriginal.GetSum().Red;
                                if (rojo > (frameOriginal.Width * frameOriginal.Height * 70))
                                    isRed = true;
                            }

                            using (Image<Bgr, byte> imageDiff = frame.ToImage<Bgr, byte>().AbsDiff(frameAnterior.ToImage<Bgr, byte>()))
                            {
                                MCvScalar diff = imageDiff.GetSum().MCvScalar;
                                if (isRed && diff.V0 > 3000000)
                                {
                                    contadorFrames++;
                                    frame.Save(Path.Combine(saveDir, "ERR_" + baseName + "_" + (++contador) + ".jpg"));
                                    frameAnterior = frame.Clone();
                                }
                                else if (diff.V0 > 3000000 && checkBuenos.Checked)
                                {
                                    frame.Save(Path.Combine(saveDir, "OK_" + baseName + "_" + (++contador) + ".jpg"));
                                    frameAnterior = frame.Clone();
                                }
                            }; //The image will be disposed here and memory freed                
                            // vw.Write(frame);
                        }
                        else if (((Item)comboBoxVISION.SelectedItem).Value == 1)
                        {
                            //PANASONIC
                            // Rectangle roi = new Rectangle(480, 145 ,(635-480), (170-145));
                            using (Image<Bgr, byte> imageDiff = frame.ToImage<Bgr, byte>().AbsDiff(frameAnterior.ToImage<Bgr, byte>()))
                            {
                                // SI FRAME ES NEGRO => IGNORAR
                                if (frame.ToImage<Bgr, byte>().Split()[0].GetSum().Intensity < frame.Height * frame.Height * 50)
                                {
                                    contadorFrames++;
                                    continue;
                                }

                                // SI FRAME ES SIMILAR AL ANTERIOR => IGNORAR
                                MCvScalar diff = imageDiff.GetSum().MCvScalar;
                                if (diff.V0 > 3000000)
                                {
                                    contadorFrames++;
                                    salvaFrame = true;
                                    // frame.Save(Path.Combine(saveDir, "FRAME_" + baseName + "_" + (++contador) + ".jpg"));
                                    frameAnterior = frame.Clone();
                                }
                            }; //The image will be disposed here and memory freed

                            if (salvaFrame)
                            {
                                frameDelay--;
                                if (frameDelay == 0)
                                {
                                    frame.Save(Path.Combine(saveDir, "FRAME_" + baseName + "_" + (++contador) + ".jpg"));
                                    salvaFrame = false;
                                    frameDelay = 2;
                                }
                            }
                            // vw.Write(frame);
                          }
                    }
                }
                catch (Exception ex)
                {
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        private void btnExtraer_Click(object sender, EventArgs e)
        {
            contadorFrames=0; 
            if ((Item)comboBoxVISION.SelectedItem != null && ((Item)comboBoxVISION.SelectedItem).Value > 0)
            {
                if (((Item)comboBoxVISION.SelectedItem).Value == 1) checkBuenos.Checked = true; //PANASONIC

                if (files.Length > 0)
                {
                    foreach (string pathVideo in files)
                    {
                        if (File.Exists(pathVideo))
                        {
                            ExtraeErrores(pathVideo);
                        }
                        else
                        {
                            MessageBox.Show("No existe el fichero \r\n" + pathVideo);
                        }
                    }
                    MessageBox.Show("FINALIZADO\r\n" + contadorFrames + " ERRORES");
                }
                else
                {
                    MessageBox.Show("No hay ficheros en: \r\n" + tbVideo.Text);
                }
            }
            else { MessageBox.Show("Seleccione sistema de vision"); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Item)comboBoxVISION.SelectedItem).Value == 1) //PANASONIC
            {
                checkBuenos.Checked = true;
            }
        }
    }
}
