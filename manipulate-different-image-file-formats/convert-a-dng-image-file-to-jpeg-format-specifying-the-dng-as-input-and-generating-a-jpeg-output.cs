using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageOptions;

class DngToJpegConverter
{
    static void Main()
    {
        // Path to the folder containing the DNG file
        string dir = @"C:\temp\";

        // Load the DNG image using Aspose.Imaging.Image.Load
        using (Image image = Image.Load(dir + "input.dng"))
        {
            // Cast the generic Image to a DngImage to access DNG-specific functionality
            DngImage dngImage = (DngImage)image;

            // Define JPEG save options (default options are sufficient for a basic conversion)
            JpegOptions jpegOptions = new JpegOptions();

            // Save the DNG image as a JPEG file
            dngImage.Save(dir + "output.jpg", jpegOptions);
        }
    }
}