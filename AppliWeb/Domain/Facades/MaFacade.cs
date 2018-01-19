using AppliWeb.Domain.Services;

namespace AppliWeb.Domain.Facades
{
    public class MaFacade
    {
        public int CalculComplexeImportant()
        {
            Service1 s1 = new Service1();
            Service2 s2 = new Service2();
            Service3 s3 = new Service3();

            return s1.GetMontantComplexe() + s2.GetAutreMontantComplexe() + s3.GetEncoreUnAutreMontantComplexe();
        }
    }
}