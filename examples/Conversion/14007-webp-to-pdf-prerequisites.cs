using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class WebPToPdfConversion
{
    static void Main()
    {
        // Prerequisite 1: Aspose.Imaging for .NET library must be referenced in the project.
        // Prerequisite 2: A valid Aspose.Imaging license should be applied (optional for evaluation).
        // Prerequisite 3: The output directory must exist and be writable.
        // Prerequisite 4: PDF export support is included in Aspose.Imaging; no additional packages are required.

        string dir = @"c:\temp\"; // Ensure this folder exists.

        // Load the WebP image from file.
        using (WebPImage webPImage = new WebPImage(Path.Combine(dir, "test.webp")))
        {
            // Convert and save the image to PDF format.
            webPImage.Save(Path.Combine(dir, "test.pdf"), new PdfOptions());
        }
    }
}