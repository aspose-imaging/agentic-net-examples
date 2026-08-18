// HOW-TO: Crop, Rotate, Flip DICOM Image and Export to GIF Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                // Crop 10 pixels from each side
                int cropLeft = 10;
                int cropTop = 10;
                int cropWidth = dicom.Width - 2 * cropLeft;
                int cropHeight = dicom.Height - 2 * cropTop;
                var cropRect = new Rectangle(cropLeft, cropTop, cropWidth, cropHeight);
                dicom.Crop(cropRect);

                // Rotate 45 degrees clockwise, resize proportionally, gray background
                dicom.Rotate(45f, true, Color.Gray);

                // Flip horizontally
                dicom.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Save as GIF
                var gifOptions = new GifOptions();
                dicom.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to generate a thumbnail GIF from a DICOM file after cropping unwanted borders and applying orientation adjustments.
 * 2. When a radiology web portal must display patient scans as GIFs with consistent rotation and horizontal flip to match viewer expectations.
 * 3. When a healthcare data pipeline converts DICOM images to a web‑friendly format while removing edge artifacts and standardizing the background color.
 * 4. When diagnostic software prepares DICOM images for inclusion in reports, requiring a 45° rotation and horizontal flip before saving as GIF.
 * 5. When a telemedicine system needs to preprocess DICOM scans by cropping, rotating, and flipping them before transmitting them as lightweight GIF files.
 */
