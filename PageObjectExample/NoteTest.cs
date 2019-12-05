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
            //utworzyć notatkę
            //wylogowa
            //nowa notatka jest opublikowana

            var blogStartPage = MainPageAdmin.Open(GetBrowser());
            var loginUser = blogStartPage.NavigateToAdminPanel();
            var exampleComment = new ExampleComment();
            var link = loginUser.AddCommentNotes(exampleComment);
            loginUser.LogOut();

            var notePage = new NotePage(GetBrowser(), link);


           Assert.True(notePage.HasMyNotes(exampleComment));

        }
    }
}
