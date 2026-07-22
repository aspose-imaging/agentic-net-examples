using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Crop the image to a rectangle (example values)
                var cropRect = new Aspose.Imaging.Rectangle(50, 50, 200, 200);
                dicom.Crop(cropRect);

                // Rotate 45 degrees clockwise, resize proportionally, white background
                dicom.Rotate(45f, true, Aspose.Imaging.Color.White);

                // Flip horizontally
                dicom.RotateFlip(Aspose.Imaging.RotateFlipType.RotateNoneFlipX);

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
 * 1. When a radiology web portal needs to generate thumbnail previews of DICOM scans with a specific region of interest highlighted, it can load the DICOM, crop to the ROI, rotate for proper orientation, flip if needed, and save as a lightweight GIF for fast browser display.
 * 2. When a medical research application must create animated GIFs that compare pre‑ and post‑procedure images, it can process each DICOM slice by cropping, rotating to a standard angle, flipping to match patient positioning, and exporting to GIF for inclusion in reports.
 * 3. When a tele‑medicine mobile app wants to send a compact visual of a patient's scan over low‑bandwidth connections, it can use the code to extract a focused area from the DICOM, adjust orientation, and convert it to a GIF that loads quickly on any device.
 * 4. When a hospital’s electronic health record system needs to embed patient scan snapshots into PDF discharge summaries, it can preprocess the DICOM with cropping, rotation, and flip operations and save as a GIF that integrates easily with PDF libraries.
 * 5. When a machine‑learning pipeline requires consistent image orientation and size before feeding DICOM data into a model, developers can use this snippet to crop, rotate, and flip the images and store them as GIFs for uniform preprocessing.
 */