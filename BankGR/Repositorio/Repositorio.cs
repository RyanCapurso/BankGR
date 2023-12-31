﻿namespace BankGR.Repositorios;

internal class Repositorio<T>
{
    List<T> listaDados = new List<T>();

    public void Adicionar(T item)
    {
        listaDados.Add(item);
    }
    public bool Excluir(T item)
    {
        listaDados.Remove(item);
        return true;
    }
    public T? ObterPorItem(Func<T, bool> predicate)
    {
        return listaDados.FirstOrDefault(predicate);
    }
    public List<T> ObterTodos()
    {
        return listaDados;
    }
    public void PersistirDados()
    { }
    public void CarregarDados()
    { }
    public void DeletarLista()
    {
        listaDados.Clear();
    }
}
