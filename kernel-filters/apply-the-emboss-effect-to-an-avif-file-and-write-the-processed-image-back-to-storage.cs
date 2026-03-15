using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Avif;          // AvifImage class
using Aspose.Imaging.Filters;                 // EmbossFilter

class Program
{
    static void Main()
    {
        // Paths to the source AVIF file and the destination file
        string inputPath = "input.avif";
        string outputPath = "output.avif";

        // Load the AVIF image (lifecycle: load)
        using (AvifImage avif = (AvifImage)Image.Load(inputPath))
        {
            // Apply the Emboss effect to the whole image (filter operation)
            avif.Filter(avif.Bounds, new EmbossFilter());

            // Save the processed image back to storage (lifecycle: save)
            avif.Save(outputPath);
        }
    }
}