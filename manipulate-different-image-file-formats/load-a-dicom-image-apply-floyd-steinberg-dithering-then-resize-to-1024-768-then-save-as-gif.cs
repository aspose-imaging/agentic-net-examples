using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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
            using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
            {
                // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                dicomImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Resize to 1024×768 using nearest neighbour resampling
                dicomImage.Resize(1024, 768, ResizeType.NearestNeighbourResample);

                // Save as GIF
                GifOptions gifOptions = new GifOptions();
                dicomImage.Save(outputPath, gifOptions);
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
 * 1. When a medical imaging web portal needs fast, low‑size preview thumbnails of DICOM scans, a developer can load the DICOM file, apply Floyd‑Steinberg dithering with a 1‑bit palette, resize it to 1024×768, and save it as a GIF for quick browser display.
 * 2. When integrating radiology images into an electronic health record system that only accepts GIF files, a developer can convert high‑resolution DICOM images to GIF using Aspose.Imaging, applying dithering and nearest‑neighbour resizing to meet the 1024×768 display requirement while preserving diagnostic contrast.
 * 3. When preparing slide decks that include medical images, a developer can use this code to transform DICOM files into GIFs with Floyd‑Steinberg dithering and a 1024×768 size, ensuring compatibility with PowerPoint and retaining visual detail on standard projectors.
 * 4. When building a mobile health app that streams DICOM scans over limited bandwidth, a developer can down‑sample the images to 1024×768, apply 1‑bit Floyd‑Steinberg dithering to reduce file size, and output GIF files that load quickly on iOS and Android devices.
 * 5. When creating an automated batch‑processing pipeline to archive DICOM studies as web‑friendly GIFs, a developer can employ this C# snippet to load each DICOM, dither it, resize to 1024×768 using nearest‑neighbour resampling, and save the result in GIF format for efficient long‑term storage.
 */