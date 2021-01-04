using GestionColegioMVC.Models;//carga os modelos da base de datos, necesarios para ApplicationDbContext

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionColegioMVC.Startup))]
namespace GestionColegioMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CrearRolesEUsuarios();//inicializamos a funcion de crear roles o iniciar a app da nosa web
        }

        /// <summary>
        /// Clase no Startup da aplicacion que se carga o inicio e permite crear os roles e usuarios da nosa web. Normalmente so e necesario correr a app unha vez, pero podese deixar
        /// </summary>
        public void CrearRolesEUsuarios()
        {
            var contexto = new ApplicationDbContext();
            var xestorRoles = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(contexto)); //inicializa RoleManager, pasamoslle IdentityRole, despois un obxeto Rolestore con IdentityRole e o valor do contexto da base de datos, coa a BD que inicializamos
            //pasa un rol de usuario as taboas da nosa BD

            var xestorUsuarios = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contexto)); //similar o anteiorpero con usuarios

            if (!xestorRoles.RoleExists("Admin")) //se un rol Admin non existe para certas operacions especificas
            {
                var rol = new IdentityRole();
                rol.Name = "Admin";
                xestorRoles.Create(rol); //creamos o Rol de Admin

                var usuario = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@hotmail.com"
                };

                var password = "password";//para simplificar, pero hai que encriptar os passwords, isto seria moi mala practica

                var usr = xestorUsuarios.Create(usuario, password);//podemos crear un usuario con ou sen password, esta funcion encargase da insercion na base de datos e da encriptacion

                if (usr.Succeeded) //se a creacion de usuario non deu erros
                {
                    var resultado = xestorUsuarios.AddToRole(usuario.Id, "Admin"); //agora asociamos ese usuario con un rol
                    //Este usuario sera moi importante
                }
            }

            //Agora creamos o rol de profesor/a
            if (!xestorRoles.RoleExists("Profe"))
            {
                var rolProfe = new IdentityRole();
                rolProfe.Name = "Profe";
                xestorRoles.Create(rolProfe); //rol de Profe creado
            }

            //Agora creamos o rol de Supervisor da BD
            if (!xestorRoles.RoleExists("Supervisor"))
            {
                var superRol = new IdentityRole();
                superRol.Name = "Supervisor";
                xestorRoles.Create(superRol); //rol de Profe creado
            }
        }
    }
}
