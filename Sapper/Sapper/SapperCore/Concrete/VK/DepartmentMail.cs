using SapperCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperCore.Concrete
{

    public class DepartmentMail : IParcel
        {
            
            public static string AppId = "5194068";
            public static string Scope = "wall";

            public static string token;
            public static string id;
            public static bool IsAuthorized;

            public static string url = "https://oauth.vk.com/authorize?client_id=" + AppId + "&redirect_uri=https://oauth.vk.com/blank.html&display=popup&scope=" + Scope + "&response_type=token&v=5.41";


            public MailСarrier Сarrier { get; set; }
            public void Send()
            {
                if(DepartmentMail.IsAuthorized==true){
                Сarrier = new MailСarrier();
                Сarrier.Send();}
            }
        }
    
}
