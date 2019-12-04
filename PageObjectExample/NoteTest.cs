using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PageObjectsExample
{
    public class NoteTest : BaseTest
    {

        [Fact]
        public void Can_publish_new_note()
        {
            //zalogowa się do panelu administracyjnego
            //utworzyć notatkę//wylogowa
            //nowa notatka jest opublikowana

            var blogStartPage = MainPageAdmin.Open(GetBrowser());
        }
    }
}
