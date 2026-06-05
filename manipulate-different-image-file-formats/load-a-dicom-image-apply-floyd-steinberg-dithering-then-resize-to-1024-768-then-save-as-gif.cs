using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                dicomImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Resize to 1024x768 using nearest neighbour resampling
                dicomImage.Resize(1024, 768, ResizeType.NearestNeighbourResample);

                // Save the result as a GIF image
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
 * 1. When a medical imaging system must convert high‑resolution DICOM scans into small 1‑bit GIF thumbnails for fast web preview, this code loads the DICOM, dithers, resizes, and saves as GIF.
 * 2. When a radiology reporting tool needs to embed lightweight GIF images of DICOM studies into electronic health record (EHR) documents, the code provides the required conversion, dithering, and resizing steps.
 * 3. When a telemedicine app has to deliver DICOM X‑ray images to mobile devices with limited bandwidth, the code creates 1024×768 GIFs using Floyd‑Steinberg dithering to retain visual detail.
 * 4. When a research workflow requires batch‑processing DICOM files into GIF format for inclusion in scientific publications, this code automates the dithering, resizing, and saving operations in C#.
 * 5. When a hospital’s PACS integration needs to generate GIF previews of DICOM studies for non‑technical staff, the code uses Aspose.Imaging to load, dither, resize, and export the images efficiently.
 */