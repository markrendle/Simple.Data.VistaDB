namespace Simple.Data.VistaDB
{
    using System.ComponentModel.Composition;
    using System.Text.RegularExpressions;
    using Ado;

    [Export(typeof(CommandOptimizer))]
    public class VistaDBCommandOptimizer : CommandOptimizer
    {
        public override System.Data.IDbCommand OptimizeFindOne(System.Data.IDbCommand command)
        {
            command.CommandText = Regex.Replace(command.CommandText, "^SELECT ", "SELECT TOP 1 ",
                                                RegexOptions.IgnoreCase);
            return command;
        }
    }
}
