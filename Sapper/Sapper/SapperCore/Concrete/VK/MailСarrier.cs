using SapperCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperCore.Concrete
{
   public class MailСarrier : IParcel
    {
        public void Send()
        {
            string state="Хм...";
            if (Scor.WonOrLost == -1) state = "Проиграл";
            if (Scor.WonOrLost == 0) state = "В раздумьях";
            if (Scor.WonOrLost == 1) state = "Выиграл";
            string message = "Всего клеток   "+ Scor.allcol+ "    Количество мин  "+Scor.mincol+ "    Клеток открыто  "+Scor.opencol+"      Состояние игры     " + state;
            string methodName = "wall.post.xml";
            string resp = HttpRequests.POST_http("https://api.vk.com/method/" + methodName + "?" + "owner_id" + "=" + DepartmentMail.id + "&message=" + message + "&access_token=" + DepartmentMail.token + "", message);
        }
    }
}
