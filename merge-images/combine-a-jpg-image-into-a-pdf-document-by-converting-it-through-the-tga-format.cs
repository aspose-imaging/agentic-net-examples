using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Paths for source JPG, intermediate TGA, and final PDF
        string jpgPath = "input.jpg";
        string tgaPath = "temp.tga";
        string pdfPath = "output.pdf";

        // Load the JPG image
        using (RasterImage jpgImage = (JpegImage)Image.Load(jpgPath))
        {
            // Convert and save the JPG as a TGA file using TgaOptions
            jpgImage.Save(tgaPath, new TgaOptions());
        }

        // Load the intermediate TGA image
        using (RasterImage tgaImage = (TgaImage)Image.Load(tgaPath))
        {
            // Save the TGA image directly as a PDF document
            // Aspose.Imaging determines the format from the file extension
            tgaImage.Save(pdfPath);
        }

        // Clean up the temporary TGA file
        if (File.Exists(tgaPath))
        {
            File.Delete(tgaPath);
        }
    }
}