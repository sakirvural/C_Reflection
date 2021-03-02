using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    //istek ve geri dönüş türlerini  istediğiniz şekilde değiştirebilmeniz için generik yapılmıştırdır 
    public class Connect<Response, Request> 
    {

        public Response Execute(Request request)
        {

        
            //dll uzantısı girin
            var assembly = Assembly.LoadFrom("C:/methodname.dll"); //1

            //istediğiniz class yazın
            var getType = assembly.GetType("class ismi"); //2

            // (string)typeof(Request).GetProperty("MethodName").GetValue(request) ile method name gönderebilirsiniz
            var method = getType.GetMethod("method ismi"); //3

           //classın yapısını çalıştırma istediğinde bulunur yapıcısına veri gönderilecekse virgülden sonra yapıcı parametleri yazılır
            var activator = Activator.CreateInstance(getType); //4

           //methoda göndereceğiniz istekleri bu şekilde bi yapıyla gönderebilirsiniz. istediğiniz yoksa new object boş  bırakın
            return (Response)method.Invoke(activator, new object[] { request });

        }
    }
    }
