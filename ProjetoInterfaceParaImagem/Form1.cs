using System.Drawing.Text;
using System.Security.Cryptography;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.IO;
using System.Linq;

namespace ProjetoInterfaceParaImagem
{
    public partial class Form1 : Form
    {

        private string[] listaImagens;
        private int currentImageIndex = 0;
        private System.Threading.Timer timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            // define um filtro para exibir apenas arquivos de imagem: 
            ofd.Filter = "Arquivos de Imagem|*.jpg; *.jpeg;*.png;*.gif;*.bmp";

            // exibe a janela de diálogo para o usuário escolher a imagem:
            DialogResult result = ofd.ShowDialog();

            // se o usuário selecionou alguma imagem, faça...
            if (result == DialogResult.OK)
            {

                string imagePath = ofd.FileName; // obtém o caminho da imagem
                pictureBox1.Image = Image.FromFile(imagePath);
                // carrega o caminho da imagem na moldura dela na interface
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string selectedFolder = fbd.SelectedPath;

                listaImagens = Directory.GetFiles(selectedFolder);

                if (listaImagens.Length > 0)
                {

                    //                 timer_Tick.Interval = 3000;
                    //                 timer_Tick.Start();

                    for (int i = 0; i < listaImagens.Length; i++)
                    {
                        if (Path.GetExtension(listaImagens[i]) == ".jpg" || Path.GetExtension(listaImagens[i]) == ".jpeg" || Path.GetExtension(listaImagens[i]) == ".png" ||
                            Path.GetExtension(listaImagens[i]) == ".gif" || Path.GetExtension(listaImagens[i]) == ".bmp" || Path.GetExtension(listaImagens[i]) == ".jpeg" ||
                            Path.GetExtension(listaImagens[i]) == ".jfif" || Path.GetExtension(listaImagens[i]) == ".svg" || Path.GetExtension(listaImagens[i]) == ".ini")
                        {

                        }
                        else
                        {
                            MessageBox.Show("Selecione uma pasta que contenha *apenas* imagens");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("A pasta está vazia. Selecione uma pasta com *imagens*.");
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            currentImageIndex = (currentImageIndex + 1) % listaImagens.Length;
            DisplayImage();
        }

        private void DisplayImage()
        {
            pictureBox1.ImageLocation = listaImagens[currentImageIndex];
        }
    }
}
