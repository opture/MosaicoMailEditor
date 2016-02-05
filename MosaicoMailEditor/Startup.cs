using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MosaicoMailEditor.Startup))]
namespace MosaicoMailEditor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
