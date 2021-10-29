﻿using Aprimo.Opti.Core.Models;
using EPiServer;
using EPiServer.Core;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;

namespace Aprimo.Opti.Core.Controllers
{
    public class AprimoThumbnailController : Controller
    {
        private readonly IContentLoader contentLoader;

        public AprimoThumbnailController(IContentLoader contentLoader)
        {
            this.contentLoader = contentLoader;
        }

        [ResponseCache(Duration = 600, VaryByQueryKeys = new[] { "contentLink" })]
        public ActionResult GenerateThumb(ContentReference contentLink)
        {
            var content = this.contentLoader.Get<AprimoImageData>(contentLink);
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(content.ThumbnailPreviewUrl);
            myWebRequest.Method = "GET";
            myWebRequest.ContentType = "image/jpeg";

            // Sends the HttpWebRequest and waits for the response.
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();

            //get Stream Data from the response
            Stream receiveStream = myHttpWebResponse.GetResponseStream(); //read the response from stream.
            return new FileStreamResult(receiveStream, "image/jpeg");
        }
    }
}