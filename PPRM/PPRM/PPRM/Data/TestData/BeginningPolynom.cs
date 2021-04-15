using System.Collections;

namespace PPRM.Data.TestData
{
    public class BeginningPolynom: IEnumerable
    {
        
            private const string Title = "Мінімальний (за кількістю операцій) поляризований поліном Ріда - Маллера:";
            private const string Polynom = "P[0] F = 0   L(P[0] F) = 0";
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { Title,Polynom };
                
            }
        
    }
}
