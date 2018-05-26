using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using WebsiteQuanLyHocNgheCuaHung.Models;

namespace WebsiteQuanLyHocNgheCuaHung.Hubs
{
    public class ChatHub : Hub
    {
        Entities db = new Entities();
        public void Send(string UserId_Gui, string TinNhan,DateTime ThoiGian, string UserID_Nhan)
        {
            Clients.All.addNewMessageToPage(UserId_Gui, TinNhan, ThoiGian, UserID_Nhan);
            //Thêm tin nhắn vào database 
            ChatBox chatBox = new ChatBox();
            chatBox.UserID_Gui = UserId_Gui;
            chatBox.TinNhan = TinNhan;
            chatBox.ThoiGian = ThoiGian;
            chatBox.UserID_Nhan = UserID_Nhan;
            db.ChatBoxes.Add(chatBox);
            db.SaveChanges();
        }
    }
}