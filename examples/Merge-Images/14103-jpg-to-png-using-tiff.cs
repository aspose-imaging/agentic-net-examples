using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class MergeJpgToPngViaTiff
{
    static void Main()
    {
        // Define file paths
        string dir = @"C:\temp\";
        string jpgPath = Path.Combine(dir, "input.jpg");
        string pngPath = Path.Combine(dir, "input.png");
        string tempTiffJpg = Path.Combine(dir, "temp_jpg.tif");
        string tempTiffPng = Path.Combine(dir, "temp_png.tif");
        string outputPng = Path.Combine(dir, "merged.png");

        // Load JPG and save it as a temporary TIFF
        using (Image jpgImage = Image.Load(jpgPath))
        {
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            jpgImage.Save(tempTiffJpg, tiffOptions);
        }

        // Load PNG and save it as a temporary TIFF
        using (Image pngImage = Image.Load(pngPath))
        {
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            pngImage.Save(tempTiffPng, tiffOptions);
        }

        // Load both temporary TIFF files as TiffImage instances
        using (TiffImage tiffJpg = (TiffImage)Image.Load(tempTiffJpg))
        using (TiffImage tiffPng = (TiffImage)Image.Load(tempTiffPng))
        {
            // Merge the frames of the second TIFF into the first TIFF
            tiffJpg.Add(tiffPng);

            // Save the merged TIFF as a PNG (first frame will be used)
            var pngOptions = new PngOptions();
            tiffJpg.Save(outputPng, pngOptions);
        }

        // Optional: delete temporary TIFF files
        File.Delete(tempTiffJpg);
        File.Delete(tempTiffPng);
    }
}