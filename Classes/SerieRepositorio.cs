using System;
using System.Collections.Generic;
using CadastroSeries.Interfaces; 

namespace CadastroSeries
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        
        private List<Serie> ListaSerie = new List<Serie>();

        public List<Serie> Listar()
        {
            return ListaSerie;
        }
        public Serie RetornarPorId(int id)
        {
            return ListaSerie[id];
        }
        public void Inserir(Serie objeto)
        {
            ListaSerie.Add(objeto);
        }  
        public void Excluir(int id)
        {
            ListaSerie[id].Excluir();  
        }  
        public void Atualizar(int id, Serie objeto)
        {
            ListaSerie[id] = objeto;
        } 

        public int ProximoId()
        {
            return ListaSerie.Count;
        }
    }
}