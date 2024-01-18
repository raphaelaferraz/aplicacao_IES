using Capitulo02.Models;

namespace Capitulo02.Data
{
    public class IESInitializer
    {
        public static void Initialize(IESContext context) 
        {
            // A base de dados é criada somente quando o método for invocado
            context.Database.EnsureCreated();

            // Verifica se há algum objeto/registro em Departamentos usando LINQ
            if(context.Departamentos.Any())
            {
                return;
            }

            var departamentos = new Departamento[]
            {
                new Departamento {Nome = "Ciência da Computação"},
                new Departamento {Nome = "Engenharia de Software"}
            };

            foreach(Departamento departamento in departamentos)
            {
                context.Departamentos.Add(departamento);
            }

            context.SaveChanges();
        }
    }
}
