using Capitulo01.Models;

namespace Capitulo01.Data
{
    public class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            // A base de dados é criada quando o método abaixo é invocado
            context.Database.EnsureCreated();

            // Verifica se há algum objeto/registro em Departamentos usando LINQ
            if(context.Departamentos.Any()) 
            {
                return;
            }

            var departamentos = new Departamento[]
            {
                new Departamento {Nome = "Ciência da Computação"},
                new Departamento {Nome = "Ciência de Alimentos"}
            };

            foreach(Departamento departamento in departamentos)
            {
                context.Departamentos.Add(departamento);
            }

            context.SaveChanges(); 
        }
    }
}
