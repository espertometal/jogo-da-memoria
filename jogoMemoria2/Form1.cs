using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// julio sperandio 
//facebook.com/julio.dragonic
namespace jogoMemoria2
{
    public partial class Form1 : Form
    {
        //Botões de referência usados para comparação
        Button button_cmp1, button_cmp2;

        //quando falso, não permite que os botões sejam clicados para que o timer execute
        bool permitirClick = true;

        //Nome do último botão clicado, pra não fazer uma comparação com 2 botões iguais
        string button_name;

        // Variavel para checar os botões, 0 para botão livre e 1 para botão usado
        int[] button_num = new int[21];
           
        public Form1()
        {
            InitializeComponent();

        }

        //##############################################################
        /*Sequeência do Código
         * 
         * 1 - Adiciona o evento click dos botões em um unico método (Botao)
         * 2 - Guarda os botões que o usuário clicou dentro de 2 variaveis (button_cmp1, button_cmp2)
         * 3 - Realiza a comparaçao com as cores (VerificarBotao)
         * 4 - Se a combinação não bater, ativa o timer para redefinir a jogada (tmr_Tick)
         * 5 - Verifica se o jogo foi completado (TerminouJogo)

        */
        //##############################################################
        private void Form1_Load(object sender, EventArgs e)
        {
            // Todos os botões são direcionado à um único método
            btn1.Click += new EventHandler(Botao);
            btn2.Click += new EventHandler(Botao);
            btn3.Click += new EventHandler(Botao);
            btn4.Click += new EventHandler(Botao);
            btn5.Click += new EventHandler(Botao);
            btn6.Click += new EventHandler(Botao);
            btn7.Click += new EventHandler(Botao);
            btn8.Click += new EventHandler(Botao);
            btn9.Click += new EventHandler(Botao);
            btn10.Click += new EventHandler(Botao);
            btn11.Click += new EventHandler(Botao);
            btn12.Click += new EventHandler(Botao);
            btn13.Click += new EventHandler(Botao);
            btn14.Click += new EventHandler(Botao);
            btn15.Click += new EventHandler(Botao);
            btn16.Click += new EventHandler(Botao);
            btn17.Click += new EventHandler(Botao);
            btn18.Click += new EventHandler(Botao);
            btn19.Click += new EventHandler(Botao);
            btn20.Click += new EventHandler(Botao);        
        }

        private void Botao(object sender, EventArgs e)
        {
            //Desabilita o click, para que o timer seja executado e não ocorra interferências
            if (!permitirClick) { return; }

            //pega o botão que foi clicado
            Button button_sender;

            //Converte o botão que está em sender do tipo object, e joga a referencia no button_sender
            button_sender = (Button)sender;
  
            //Se os dois botões já estiverem sendo usados para comparação, sai do método para evitar processamento desnecessário
            //e erros no programa
            if (button_cmp1 != null && button_cmp2 != null) { return; }

            //se o primeiro botão de comparação for vazio
            if (button_cmp1 == null)
            {
                //pega o nome botão
                button_name = button_sender.Name;
                //joga o botão clicado para a primeira comparação
                button_cmp1 = button_sender;
            }
            // se o segundo botão de comparação for vazio
            else if (button_cmp2 == null) 
            {
                //verifica se o botão clicado, é o mesmo que o botão anterior, se sim, sai do método 
                // para permitir que o usuário possa escolher outro
                if (button_sender.Name == button_name) { return; }

                //se o segundo botão clicado for diferente do botao anterior, joga dentro da segunda variavel de comparação
                button_cmp2 = button_sender; 
            }

            //de acordo com o nome dos botões, define as cores
            switch (button_sender.Name)
            {
                case "btn1": button_sender.BackColor = Color.Yellow; break;
                case "btn2": button_sender.BackColor = Color.Red; break;
                case "btn3": button_sender.BackColor = Color.Yellow; break;
                case "btn4": button_sender.BackColor = Color.Blue; break;
                case "btn5": button_sender.BackColor = Color.Brown; break;
                case "btn6": button_sender.BackColor = Color.Coral; break;
                case "btn7": button_sender.BackColor = Color.DarkCyan; break;
                case "btn8": button_sender.BackColor = Color.Indigo; break;
                case "btn9": button_sender.BackColor = Color.HotPink; break;
                case "btn10": button_sender.BackColor = Color.MistyRose; break;
                case "btn11": button_sender.BackColor = Color.Navy; break;
                case "btn12": button_sender.BackColor = Color.Red; break;
                case "btn13": button_sender.BackColor = Color.Blue; break;
                case "btn14": button_sender.BackColor = Color.Brown; break;
                case "btn15": button_sender.BackColor = Color.Coral; break;
                case "btn16": button_sender.BackColor = Color.DarkCyan; break;
                case "btn17": button_sender.BackColor = Color.MistyRose; break;
                case "btn18": button_sender.BackColor = Color.Indigo; break;
                case "btn19": button_sender.BackColor = Color.HotPink; break;
                case "btn20": button_sender.BackColor = Color.Navy; break;
            }

            // Chama a comparação dos botões
            VerificarBotao();

            //Mostra a mensagem quando todos os botões estivem completos
            if (TerminouJogo() == true) { MessageBox.Show("Você terminou o jogo " + "Parabéns !!!"); }

 
        }

        private bool TerminouJogo()
        {

            // percorre todos os botões
            for (int n = 1; n <= 20; n++)
            {
                //se encontrar algum botão com 0, o jogo ainda não está completo e retorna false
                //obs: retornando false, sai automaticamente do laço FOR não executando o que está abaixo do laço
                if (button_num[n] == 0) { return false; }
            }

            //se percorrer todo o laço e não encontrar nenhum 0, nada irá acontecer e o código irá continuar 
            // nenhum 0 = todos os botões já foram completados
            return true;
        }

        private void VerificarBotao()
        {
            //verifica se as duas variaveis de comparação estão completas
            // se não estiver, sai do método para que o usuário escolha os botões

            //obs: só é possível a comparação quando os 2 botões já estiverem selecionados
            if (button_cmp1 == null || button_cmp2 == null) { return; }

            //se as cores forem iguais
            if (button_cmp1.BackColor == button_cmp2.BackColor)
            {
                //desabilita para que mais nenhuma ação ocorra
                button_cmp1.Enabled = false;
                button_cmp2.Enabled = false;

                //define o valor 1 para o lugar correspondente ao texto do botão
                button_num[int.Parse(button_cmp1.Text)] = 1;
                button_num[int.Parse(button_cmp2.Text)] = 1;

                button_cmp1.Text = "OK";
                button_cmp2.Text = "OK";

                //muda para nullo as duas variaveis de comparação
                // para que o jogo continue com novos botoões
                button_cmp1 = null;
                button_cmp2 = null;
            }
            else
            {
                //se as cores dois botões não batem
                //desabilita a ação dos botões e liga o timer
                permitirClick = false;
                tmr1.Start();
            }
               
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            //até completar 1 segundo, os botões ficam com as cores das combinações
            //para que o usuário possa memorizar


            //quando se passar 1 segundo       
            //as cores voltam ao normal
            button_cmp1.BackColor = Color.Gray;
            button_cmp2.BackColor = Color.Gray;

            //as variaveis são alteradas para nullo, para que o jogo continue 
            button_cmp1 = null;
            button_cmp2 = null;

            //permite novamente a ação dos botões e para o timer
            permitirClick = true;
            tmr1.Stop();
        }  

    }
}
