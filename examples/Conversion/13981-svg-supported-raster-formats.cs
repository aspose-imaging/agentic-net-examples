using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Retrieve the set of export formats registered in Aspose.Imaging
        FileFormat registeredFormats = ImageExportersRegistry.RegisteredFormats;

        // Define the raster formats that can be used as output for SVG conversion
        FileFormat[] rasterFormats = new FileFormat[]
        {
            FileFormat.Bmp,
            FileFormat.Gif,
            FileFormat.Jpeg,
            FileFormat.Png,
            FileFormat.Tiff
        };

        Console.WriteLine("Supported raster output formats for SVG conversion:");
        foreach (FileFormat fmt in rasterFormats)
        {
            // Check if the particular raster format is present in the registered set
            if ((registeredFormats & fmt) == fmt)
            {
                Console.WriteLine("- " + fmt);
            }
        }
    }
}