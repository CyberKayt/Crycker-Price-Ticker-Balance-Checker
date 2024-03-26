namespace DaddyRecoveryBuilder.Helpers
{
    using System;
    using Editors;

    public static class AssTools
    {
        public static void WriteAssembly(string filename, AssemblyCollector build)
        {
            try
            {
                var versionResource = new AssemblyEditor();
                versionResource.LoadFrom(filename);
                versionResource.Language = 0;

                var stringFileInfo = (StringFileInfo)versionResource["StringFileInfo"];
                stringFileInfo["ProductName"] = build.ProductInfo;
                stringFileInfo["FileDescription"] = build.FileDescriptInfo;
                stringFileInfo["CompanyName"] = build.CompanyNameInfo;
                stringFileInfo["LegalCopyright"] = build.LegalCopyrightInfo;
                stringFileInfo["LegalTrademarks"] = build.LegalCopyrightInfo;
                stringFileInfo["InternalName"] = build.InternalNameInfo;
                stringFileInfo["OriginalFilename"] = build.OriginalFilenameInfo;
                stringFileInfo["Assembly Version"] = versionResource.ProductVersion;
                stringFileInfo["ProductVersion"] = build.ProductVersionInfo ?? versionResource.ProductVersion;
                stringFileInfo["FileVersion"] = build.FileVersionInfo ?? versionResource.FileVersion;

                versionResource.SaveTo(filename);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Assembly: {ex.Message}");
            }
        }
    }
}