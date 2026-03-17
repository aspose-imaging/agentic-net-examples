using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Paths (adjust as needed)
        string inputWebP = "input.webp";
        string outputPng = "decoded.png";
        string outputResizedWebP = "resized.webp";
        string outputCroppedWebP = "cropped.webp";
        string outputCreatedWebP = "created.webp";

        // ------------------------------
        // Decode: Load WebP and save as PNG
        // ------------------------------
        using (WebPImage webP = new WebPImage(inputWebP))
        {
            webP.Save(outputPng, new PngOptions());
        }

        // ------------------------------
        // Transform: Resize WebP (2x larger) and save
        // ------------------------------
        using (WebPImage webPResize = new WebPImage(inputWebP))
        {
            int newWidth = webPResize.Width * 2;
            int newHeight = webPResize.Height * 2;
            webPResize.Resize(newWidth, newHeight, ResizeType.LanczosResample);

            var resizeOptions = new WebPOptions
            {
                Lossless = false,
                Quality = 80f
            };
            webPResize.Save(outputResizedWebP, resizeOptions);
        }

        // ------------------------------
        // Transform: Crop a central region and save
        // ------------------------------
        using (WebPImage webPCrop = new WebPImage(inputWebP))
        {
            if (!webPCrop.IsCached)
                webPCrop.CacheData();

            // Define a rectangle (e.g., central 50% area)
            int cropWidth = webPCrop.Width / 2;
            int cropHeight = webPCrop.Height / 2;
            int x = (webPCrop.Width - cropWidth) / 2;
            int y = (webPCrop.Height - cropHeight) / 2;
            var rect = new Rectangle(x, y, cropWidth, cropHeight);

            webPCrop.Crop(rect);

            var cropOptions = new WebPOptions
            {
                Lossless = true,
                Quality = 100f
            };
            webPCrop.Save(outputCroppedWebP, cropOptions);
        }

        // ------------------------------
        // Encode: Create a new blank WebP, draw a red rectangle, and save
        // ------------------------------
        var createOptions = new WebPOptions
        {
            Lossless = true,
            Quality = 100f
        };
        using (WebPImage newWebP = new WebPImage(200, 200, createOptions))
        {
            // Draw a solid red rectangle covering the whole canvas
            Graphics graphics = new Graphics(newWebP);
            SolidBrush brush = new SolidBrush(Color.Red);
            graphics.FillRectangle(brush, newWebP.Bounds);

            // Save the created WebP image
            newWebP.Save(outputCreatedWebP);
        }
    }
}