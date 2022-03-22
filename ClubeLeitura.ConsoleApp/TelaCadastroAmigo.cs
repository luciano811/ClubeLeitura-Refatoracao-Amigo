
using System;

namespace ClubeLeitura.ConsoleApp
{
    public class TelaCadastroAmigo
    {
        public Amigo[] amigos;
        public int numeroAmigo;
        public Notificador notificador;

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de amigos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovaAmigo()
        {
            MostrarTitulo("Inserindo nova Amigo");

            Amigo Amigo = ObterAmigo();

            Amigo.idAmigo = numeroAmigo++;

            int posicaoVazia = ObterPosicaoVazia();
            amigos[posicaoVazia] = Amigo;

            notificador.ApresentarMensagem("Amigo inserida com sucesso!", "Sucesso");
        }

        private Amigo ObterAmigo()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável : ");
            string nomeResponsavel = Console.ReadLine();
            
            Console.Write("Digite o telefone: ");
            int telefone = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o endereço: ");
            string endereco = Console.ReadLine();

            Amigo Amigo = new Amigo();

            Amigo.nome = nome;
            Amigo.nomeResponsavel = nomeResponsavel;
            Amigo.telefone = telefone;
            Amigo.endereco = endereco;


            return Amigo;
        }

        public void EditarAmigo()
        {
            MostrarTitulo("Editando Amigo");

            VisualizarAmigos("Pesquisando");

            Console.Write("Digite o número da Amigo que deseja editar: ");
            int numeroAmigo = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].idAmigo == numeroAmigo)
                {
                    Amigo amigo = ObterAmigo();

                    amigo.idAmigo = numeroAmigo;
                    amigos[i] = amigo;

                    break;
                }
            }

            notificador.ApresentarMensagem("Amigo editado com sucesso", "Sucesso");
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        public void ExcluirAmigo()
        {
            MostrarTitulo("Excluindo Amigo");

            VisualizarAmigos("Pesquisando");

            Console.Write("Digite ID do Amigo que deseja excluir: ");
            int numeroAmigo = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].idAmigo == numeroAmigo)
                {
                    amigos[i] = null;
                    break;
                }
            }

            notificador.ApresentarMensagem("Amigo excluída com sucesso", "Sucesso");
        }

        public void VisualizarAmigos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Revistas");

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    continue;

                Amigo a = amigos[i];

                Console.WriteLine("Id do Amigo: " + a.idAmigo);
                Console.WriteLine("Nome: " + a.nome);
                Console.WriteLine("Responsável: " + a.nomeResponsavel);
                Console.WriteLine("Telefone: " + a.telefone);
                Console.WriteLine("Endereço: " + a.endereco);

                Console.WriteLine();
            }
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }

        
    }
}