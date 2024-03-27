using System.Drawing.Text;
using System.Security.Cryptography;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoInterfaceParaImagem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            // define um filtro para exibir apenas arquivos de imagem: 
            ofd.Filter = "Arquivos de Imagem|*.jpg; *.jpeg;*.png;*.gif;*.bmp";

            // exibe a janela de di�logo para o usu�rio escolher a imagem:
            DialogResult result = ofd.ShowDialog();

            // se o usu�rio selecionou alguma imagem, fa�a...
            if (result == DialogResult.OK)
            {

                string imagePath = ofd.FileName; // obt�m o caminho da imagem
                pictureBox1.Image = Image.FromFile(imagePath);
                // carrega o caminho da imagem na moldura dela na interface
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
                  
        }
    }
}
