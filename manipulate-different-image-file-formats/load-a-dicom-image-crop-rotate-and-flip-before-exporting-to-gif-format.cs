using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load DICOM image
            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                // Crop the image (example: remove 10 pixels from each side)
                int cropMargin = 10;
                int cropX = cropMargin;
                int cropY = cropMargin;
                int cropWidth = dicom.Width - 2 * cropMargin;
                int cropHeight = dicom.Height - 2 * cropMargin;
                var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                dicom.Crop(cropRect);

                // Rotate the image 45 degrees clockwise, resizing proportionally, with gray background
                dicom.Rotate(45f, true, Color.Gray);

                // Flip the image horizontally
                dicom.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Save the processed image as GIF
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
 * 1. When a healthcare application needs to extract a region of interest from a DICOM radiology scan, rotate it for better orientation, flip it for left‑right correction, and then deliver the result as a lightweight GIF for web preview.
 * 2. When a research tool must batch‑process DICOM images, trim unwanted borders, apply a 45‑degree rotation with a gray background, and save the transformed frames as GIF animations for inclusion in presentations.
 * 3. When a telemedicine portal wants to convert patient DICOM files into GIF thumbnails that are cropped, rotated, and horizontally flipped to match the viewer’s perspective before embedding them in HTML reports.
 * 4. When a diagnostic imaging system requires on‑the‑fly manipulation of a DICOM image—cropping excess padding, rotating to align anatomical landmarks, flipping horizontally, and exporting to GIF for quick sharing with colleagues.
 * 5. When a medical imaging workflow automates the preparation of DICOM scans for machine‑learning pipelines, performing crop, rotate, and flip operations in C# and saving the pre‑processed output as GIF for visualization and debugging.
 */