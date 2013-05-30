using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageResizer;

namespace ImageHelperWithResize.Controllers
{
    public class ImageController : Controller
    {
        public ActionResult Image(string image)
        {
            var imagesPath = Server.MapPath("/Images");
            var imageLocation = Path.Combine(imagesPath, image);

            return File(imageLocation, "image/jpeg");
        }

        public ActionResult ImageResize(string image, int width, int height)
        {
            var imagesPath = Server.MapPath("/Images");
            var imageLocation = Path.Combine(imagesPath, image);

            var settings = new ResizeSettings
            {
                Format = "jpg",
                Mode = FitMode.Stretch,
                Width = width,
                Height = height,
                Scale = ScaleMode.Both
            };

            var outStream = new MemoryStream();
            ImageBuilder.Current.Build(System.IO.File.ReadAllBytes(imageLocation), outStream, settings);
            var resizedImage = outStream.ToArray();

            return File(resizedImage, "image/jpeg");
        }
    }
}
