using Portafolio.Models.DTOs;

namespace Portafolio.Services
{
    public interface IRepositoryProjects
    {
        List<ProyectoDTO> GetProyects();
    }

    public class RepositoryProjects: IRepositoryProjects
    {
        public List<ProyectoDTO> GetProyects()
        {
            return new List<ProyectoDTO>() {
                new ProyectoDTO {
                    Titulo = "Amazon",
                    Descripcion = "E-Commerce realizado en ASP.Net Core",
                    Link = "https://www.amazon.com.mx",
                    ImagenURL = "/imagenes/amazon.png"
                },
                new ProyectoDTO {
                    Titulo = "New York Times",
                    Descripcion = "Páginas de noticias en React",
                    Link = "https://www.nytimes.com",
                    ImagenURL = "/imagenes/nyt.png"
                },
                new ProyectoDTO {
                    Titulo = "Reddit",
                    Descripcion = "Red social para compartir en comunidades",
                    Link = "https://www.reddit.com",
                    ImagenURL = "/imagenes/reddit.png"
                },
                new ProyectoDTO {
                    Titulo = "Steam",
                    Descripcion = "Tienda en línea para comprar vídeojeugos",
                    Link = "www.steam.com",
                    ImagenURL = "/imagenes/steam.png"
                }
            };
        }
    }
}
