using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Input CMX file path
        string inputPath = @"C:\Temp\sample.cmx";
        // Output PNG file path
        string outputPath = @"C:\Temp\sample_converted.png";

        // Load the CMX image
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            // Cache the default page
            cmxImage.CacheData();

            // Cache all pages to avoid further data loading
            foreach (CmxImagePage page in cmxImage.Pages)
            {
                page.CacheData();

                // Example operation: resize each page to half its original size
                int newWidth = page.Width / 2;
                int newHeight = page.Height / 2;
                if (newWidth > 0 && newHeight > 0)
                {
                    page.Resize(newWidth, newHeight);
                }
            }

            // Save the CMX image as a raster PNG
            cmxImage.Save(outputPath, new PngOptions());
        }
    }
}