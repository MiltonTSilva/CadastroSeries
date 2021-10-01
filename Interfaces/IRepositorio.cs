using System.Collections.Generic;

namespace CadastroSeries.Interfaces
{
    public interface IRepositorio<t>
    {
        List<t> Listar();
        t RetornarPorId(int id);
        void Inserir(t entidade);  
        void Excluir(int id);  
        void Atualizar(int id, t entidade);  
        int ProximoId();
    }
}