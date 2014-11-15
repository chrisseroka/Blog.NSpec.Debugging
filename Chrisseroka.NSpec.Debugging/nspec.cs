using System.Linq;
using NSpec;
using NSpec.Domain;
using NSpec.Domain.Formatters;
using NUnit.Framework;

namespace Chrisseroka.NSpec.Debugging
{
    [TestFixture]
    public abstract class nspec: global::NSpec.nspec
    {
        [Test]
        public void debug()
        {
            var currentSpec = this.GetType();
            var finder = new SpecFinder(new[] {currentSpec});
            var builder = new ContextBuilder(finder, new Tags().Parse(currentSpec.Name), new DefaultConventions());
            var runner = new ContextRunner(builder, new ConsoleFormatter(), false);
            var results = runner.Run(builder.Contexts().Build());

            //assert that there aren't any failures
            results.Failures().Count().should_be(0);
        }
    }
}
