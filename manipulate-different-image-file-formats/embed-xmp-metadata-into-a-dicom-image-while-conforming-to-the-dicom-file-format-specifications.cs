using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path and output DICOM file path
        string inputPath = "input.jpg";
        string outputPath = "output.dcm";

        // Create DICOM options and embed XMP metadata
        var dicomOptions = new DicomOptions();

        // Build DICOM XMP package with sample metadata
        var dicomPackage = new Aspose.Imaging.Xmp.Schemas.Dicom.DicomPackage();
        dicomPackage.SetPatientName("John Doe");
        dicomPackage.SetPatientId("123456");
        dicomPackage.SetStudyDescription("Chest CT");
        dicomPackage.SetSeriesDescription("Axial slices");
        dicomPackage.SetEquipmentManufacturer("Acme Imaging");
        dicomPackage.SetEquipmentInstitution("General Hospital");

        // Assign the XMP package to the DICOM options
        dicomOptions.XmpData = new Aspose.Imaging.Xmp.XmpPacketWrapper(dicomPackage);

        // Load the source image and save it as DICOM with embedded XMP metadata
        using (Image image = Image.Load(inputPath))
        {
            image.Save(outputPath, dicomOptions);
        }
    }
}