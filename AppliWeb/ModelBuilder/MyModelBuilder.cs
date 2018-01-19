using AppliWeb.Models;
using AppliWeb.Domain.Facades;

namespace AppliWeb.ModelBuilder
{
    public class MyModelBuilder
    {
        public AboutViewModel createAboutVM()
        {
            MaFacade facadeMetier = new MaFacade();

            return new AboutViewModel(){
                MyProperty = "super cool !",
                ValeurComplexe = facadeMetier.CalculComplexeImportant()
            };
        }
    }
}