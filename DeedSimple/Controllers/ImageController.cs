using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;
using DeedSimple.BLL.Interface;
using DeedSimple.ViewModel.Image;

namespace DeedSimple.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageProcessor _imageProcessor;
        private readonly HashSet<string> _validImageTypes;
        private readonly string _fileStorePath;

        public ImageController(IImageProcessor imageProcessor)
        {
            _imageProcessor = imageProcessor;

            _validImageTypes = new HashSet<string>
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            _fileStorePath = HostingEnvironment.MapPath("~/App_Data/UploadedImages");
        }

        // GET: Image
        [AllowAnonymous]
        public ActionResult Index(long id)
        {
            var image = _imageProcessor.GetImage(id);
            return File(GetImageFilePath(image.FileName), image.ContentType);
        }

        public ActionResult Add(long propertyId)
        {
            return View(new AddPropertyImageModel{PropertyId = propertyId});
        }

        [HttpPost]
        public ActionResult Add(AddPropertyImageModel model)
        {
            if (model.Image == null || model.Image.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (!_validImageTypes.Contains(model.Image.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }

            if (ModelState.IsValid)
            {
                if (model.Image != null && model.Image.ContentLength > 0)
                {
                    var fileGuid = Guid.NewGuid().ToString();
                    var imagePath = GetImageFilePath(fileGuid);

                    // Make sure the generated Guid / file name is unique.
                    while (System.IO.File.Exists(imagePath))
                    {
                        fileGuid = Guid.NewGuid().ToString();
                        imagePath = GetImageFilePath(fileGuid);
                    }

                    if (!Directory.Exists(_fileStorePath))
                        Directory.CreateDirectory(_fileStorePath);

                    model.Image.SaveAs(imagePath);
                    var imageId = _imageProcessor.AddImage(model, fileGuid, model.Image.ContentType);
                }

                return RedirectToAction("Edit", "Seller", new {propertyId = model.PropertyId});
            }

            return View(model);
        }

        [NonAction]
        private string GetImageFilePath(string fileName)
        {
            return Path.Combine(_fileStorePath, fileName);
        }
    }
}