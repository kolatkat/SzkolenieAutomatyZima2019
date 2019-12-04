using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PageObjectsExample
{
    public class CommentTests: BaseTest
    {
        [Fact]
        public void Can_add_new_comment_to_latest_note()
        {
            var blogStartPage = MainPage.Open(GetBrowser());
            var note = blogStartPage.NavigateToNewestNote();
            var exampleComment = new ExampleComment();
            var noteWithComment = note.AddComment(exampleComment);

            Assert.True(noteWithComment.Has(exampleComment));                        
        }


    }
}
