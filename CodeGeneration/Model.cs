using System.Collections.Generic;

namespace CodeGeneration
{
    public class TableInfo
    {
        public string TableDescribe { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string IdentityKey { get; set; }
        public string PrimaryKey { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public string Default { get; set; }
        public string Describe { get; set; }
    }

    public class Info
    {
        public string SolutionPath { get; set; }
        public string Dal { get; set; }
        public string Bll { get; set; }
        // ReSharper disable once InconsistentNaming
        public string IBll { get; set; }
        public string Model { get; set; }
        // ReSharper disable once InconsistentNaming
        public string DBName { get; set; }
        public string DBService { get; set; }
        public bool Factory { get; set; }
        // ReSharper disable once InconsistentNaming
        public string IDal { get; set; }
        public string Common { get; set; }
        public string Infrastructure { get; set; }
    }

    #region csproj

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003", IsNullable = false)]
    public partial class Project
    {

        private List<object> itemsField;

        private decimal toolsVersionField;

        private string defaultTargetsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Import", typeof(ProjectImport))]
        [System.Xml.Serialization.XmlElementAttribute("ItemGroup", typeof(ProjectItemGroup))]
        [System.Xml.Serialization.XmlElementAttribute("ProjectExtensions", typeof(ProjectProjectExtensions))]
        [System.Xml.Serialization.XmlElementAttribute("PropertyGroup", typeof(ProjectPropertyGroup))]
        [System.Xml.Serialization.XmlElementAttribute("Target", typeof(ProjectTarget))]
        public List<object> Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ToolsVersion
        {
            get
            {
                return this.toolsVersionField;
            }
            set
            {
                this.toolsVersionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DefaultTargets
        {
            get
            {
                return this.defaultTargetsField;
            }
            set
            {
                this.defaultTargetsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectImport
    {

        private string projectField;

        private string conditionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Project
        {
            get
            {
                return this.projectField;
            }
            set
            {
                this.projectField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectItemGroup
    {

        private List<ProjectItemGroupProjectReference> projectReferenceField;

        private ProjectItemGroupFolder[] folderField;

        private List<ProjectItemGroupCompile> compileField;

        private ProjectItemGroupContent[] contentField;

        private ProjectItemGroupNone[] noneField;

        private ProjectItemGroupReference[] referenceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectReference")]
        public List<ProjectItemGroupProjectReference> ProjectReference
        {
            get
            {
                return this.projectReferenceField;
            }
            set
            {
                this.projectReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Folder")]
        public ProjectItemGroupFolder[] Folder
        {
            get
            {
                return this.folderField;
            }
            set
            {
                this.folderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Compile")]
        public List<ProjectItemGroupCompile> Compile
        {
            get
            {
                return this.compileField;
            }
            set
            {
                this.compileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Content")]
        public ProjectItemGroupContent[] Content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("None")]
        public ProjectItemGroupNone[] None
        {
            get
            {
                return this.noneField;
            }
            set
            {
                this.noneField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Reference")]
        public ProjectItemGroupReference[] Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectItemGroupProjectReference
    {

        private string projectField;

        private string nameField;

        private string includeField;

        /// <remarks/>
        public string Project
        {
            get
            {
                return this.projectField;
            }
            set
            {
                this.projectField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Include
        {
            get
            {
                return this.includeField;
            }
            set
            {
                this.includeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectItemGroupFolder
    {

        private string includeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Include
        {
            get
            {
                return this.includeField;
            }
            set
            {
                this.includeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectItemGroupCompile
    {

        private string dependentUponField;

        private string includeField;

        /// <remarks/>
        public string DependentUpon
        {
            get
            {
                return this.dependentUponField;
            }
            set
            {
                this.dependentUponField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Include
        {
            get
            {
                return this.includeField;
            }
            set
            {
                this.includeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectItemGroupContent
    {

        private string copyToOutputDirectoryField;

        private string subTypeField;

        private string includeField;

        /// <remarks/>
        public string CopyToOutputDirectory
        {
            get
            {
                return this.copyToOutputDirectoryField;
            }
            set
            {
                this.copyToOutputDirectoryField = value;
            }
        }

        /// <remarks/>
        public string SubType
        {
            get
            {
                return this.subTypeField;
            }
            set
            {
                this.subTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Include
        {
            get
            {
                return this.includeField;
            }
            set
            {
                this.includeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectItemGroupNone
    {

        private string dependentUponField;

        private string includeField;

        /// <remarks/>
        public string DependentUpon
        {
            get
            {
                return this.dependentUponField;
            }
            set
            {
                this.dependentUponField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Include
        {
            get
            {
                return this.includeField;
            }
            set
            {
                this.includeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectItemGroupReference
    {

        private string hintPathField;

        private string privateField;

        private string includeField;

        /// <remarks/>
        public string HintPath
        {
            get
            {
                return this.hintPathField;
            }
            set
            {
                this.hintPathField = value;
            }
        }

        /// <remarks/>
        public string Private
        {
            get
            {
                return this.privateField;
            }
            set
            {
                this.privateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Include
        {
            get
            {
                return this.includeField;
            }
            set
            {
                this.includeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectProjectExtensions
    {

        private ProjectProjectExtensionsVisualStudio visualStudioField;

        /// <remarks/>
        public ProjectProjectExtensionsVisualStudio VisualStudio
        {
            get
            {
                return this.visualStudioField;
            }
            set
            {
                this.visualStudioField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectProjectExtensionsVisualStudio
    {

        private ProjectProjectExtensionsVisualStudioFlavorProperties flavorPropertiesField;

        /// <remarks/>
        public ProjectProjectExtensionsVisualStudioFlavorProperties FlavorProperties
        {
            get
            {
                return this.flavorPropertiesField;
            }
            set
            {
                this.flavorPropertiesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectProjectExtensionsVisualStudioFlavorProperties
    {

        private ProjectProjectExtensionsVisualStudioFlavorPropertiesWebProjectProperties webProjectPropertiesField;

        private string gUIDField;

        /// <remarks/>
        public ProjectProjectExtensionsVisualStudioFlavorPropertiesWebProjectProperties WebProjectProperties
        {
            get
            {
                return this.webProjectPropertiesField;
            }
            set
            {
                this.webProjectPropertiesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string GUID
        {
            get
            {
                return this.gUIDField;
            }
            set
            {
                this.gUIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectProjectExtensionsVisualStudioFlavorPropertiesWebProjectProperties
    {

        private string useIISField;

        private string autoAssignPortField;

        private ushort developmentServerPortField;

        private string developmentServerVPathField;

        private string iISUrlField;

        private string nTLMAuthenticationField;

        private string useCustomServerField;

        private object customServerUrlField;

        private string saveServerSettingsInUserFileField;

        /// <remarks/>
        public string UseIIS
        {
            get
            {
                return this.useIISField;
            }
            set
            {
                this.useIISField = value;
            }
        }

        /// <remarks/>
        public string AutoAssignPort
        {
            get
            {
                return this.autoAssignPortField;
            }
            set
            {
                this.autoAssignPortField = value;
            }
        }

        /// <remarks/>
        public ushort DevelopmentServerPort
        {
            get
            {
                return this.developmentServerPortField;
            }
            set
            {
                this.developmentServerPortField = value;
            }
        }

        /// <remarks/>
        public string DevelopmentServerVPath
        {
            get
            {
                return this.developmentServerVPathField;
            }
            set
            {
                this.developmentServerVPathField = value;
            }
        }

        /// <remarks/>
        public string IISUrl
        {
            get
            {
                return this.iISUrlField;
            }
            set
            {
                this.iISUrlField = value;
            }
        }

        /// <remarks/>
        public string NTLMAuthentication
        {
            get
            {
                return this.nTLMAuthenticationField;
            }
            set
            {
                this.nTLMAuthenticationField = value;
            }
        }

        /// <remarks/>
        public string UseCustomServer
        {
            get
            {
                return this.useCustomServerField;
            }
            set
            {
                this.useCustomServerField = value;
            }
        }

        /// <remarks/>
        public object CustomServerUrl
        {
            get
            {
                return this.customServerUrlField;
            }
            set
            {
                this.customServerUrlField = value;
            }
        }

        /// <remarks/>
        public string SaveServerSettingsInUserFile
        {
            get
            {
                return this.saveServerSettingsInUserFileField;
            }
            set
            {
                this.saveServerSettingsInUserFileField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectPropertyGroup
    {

        private ProjectPropertyGroupVisualStudioVersion visualStudioVersionField;

        private ProjectPropertyGroupVSToolsPath vSToolsPathField;

        private bool debugSymbolsField;

        private bool debugSymbolsFieldSpecified;

        private string debugTypeField;

        private bool optimizeField;

        private bool optimizeFieldSpecified;

        private string outputPathField;

        private string defineConstantsField;

        private string errorReportField;

        private byte warningLevelField;

        private bool warningLevelFieldSpecified;

        private ProjectPropertyGroupConfiguration configurationField;

        private ProjectPropertyGroupPlatform platformField;

        private object productVersionField;

        private decimal schemaVersionField;

        private bool schemaVersionFieldSpecified;

        private string projectGuidField;

        private string projectTypeGuidsField;

        private string outputTypeField;

        private string appDesignerFolderField;

        private string rootNamespaceField;

        private string assemblyNameField;

        private string targetFrameworkVersionField;

        private bool useIISExpressField;

        private bool useIISExpressFieldSpecified;

        private object iISExpressSSLPortField;

        private object iISExpressAnonymousAuthenticationField;

        private object iISExpressWindowsAuthenticationField;

        private object iISExpressUseClassicPipelineModeField;

        private object useGlobalApplicationHostFileField;

        private object nuGetPackageImportStampField;

        private string conditionField;

        /// <remarks/>
        public ProjectPropertyGroupVisualStudioVersion VisualStudioVersion
        {
            get
            {
                return this.visualStudioVersionField;
            }
            set
            {
                this.visualStudioVersionField = value;
            }
        }

        /// <remarks/>
        public ProjectPropertyGroupVSToolsPath VSToolsPath
        {
            get
            {
                return this.vSToolsPathField;
            }
            set
            {
                this.vSToolsPathField = value;
            }
        }

        /// <remarks/>
        public bool DebugSymbols
        {
            get
            {
                return this.debugSymbolsField;
            }
            set
            {
                this.debugSymbolsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DebugSymbolsSpecified
        {
            get
            {
                return this.debugSymbolsFieldSpecified;
            }
            set
            {
                this.debugSymbolsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string DebugType
        {
            get
            {
                return this.debugTypeField;
            }
            set
            {
                this.debugTypeField = value;
            }
        }

        /// <remarks/>
        public bool Optimize
        {
            get
            {
                return this.optimizeField;
            }
            set
            {
                this.optimizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OptimizeSpecified
        {
            get
            {
                return this.optimizeFieldSpecified;
            }
            set
            {
                this.optimizeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string OutputPath
        {
            get
            {
                return this.outputPathField;
            }
            set
            {
                this.outputPathField = value;
            }
        }

        /// <remarks/>
        public string DefineConstants
        {
            get
            {
                return this.defineConstantsField;
            }
            set
            {
                this.defineConstantsField = value;
            }
        }

        /// <remarks/>
        public string ErrorReport
        {
            get
            {
                return this.errorReportField;
            }
            set
            {
                this.errorReportField = value;
            }
        }

        /// <remarks/>
        public byte WarningLevel
        {
            get
            {
                return this.warningLevelField;
            }
            set
            {
                this.warningLevelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WarningLevelSpecified
        {
            get
            {
                return this.warningLevelFieldSpecified;
            }
            set
            {
                this.warningLevelFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ProjectPropertyGroupConfiguration Configuration
        {
            get
            {
                return this.configurationField;
            }
            set
            {
                this.configurationField = value;
            }
        }

        /// <remarks/>
        public ProjectPropertyGroupPlatform Platform
        {
            get
            {
                return this.platformField;
            }
            set
            {
                this.platformField = value;
            }
        }

        /// <remarks/>
        public object ProductVersion
        {
            get
            {
                return this.productVersionField;
            }
            set
            {
                this.productVersionField = value;
            }
        }

        /// <remarks/>
        public decimal SchemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SchemaVersionSpecified
        {
            get
            {
                return this.schemaVersionFieldSpecified;
            }
            set
            {
                this.schemaVersionFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string ProjectGuid
        {
            get
            {
                return this.projectGuidField;
            }
            set
            {
                this.projectGuidField = value;
            }
        }

        /// <remarks/>
        public string ProjectTypeGuids
        {
            get
            {
                return this.projectTypeGuidsField;
            }
            set
            {
                this.projectTypeGuidsField = value;
            }
        }

        /// <remarks/>
        public string OutputType
        {
            get
            {
                return this.outputTypeField;
            }
            set
            {
                this.outputTypeField = value;
            }
        }

        /// <remarks/>
        public string AppDesignerFolder
        {
            get
            {
                return this.appDesignerFolderField;
            }
            set
            {
                this.appDesignerFolderField = value;
            }
        }

        /// <remarks/>
        public string RootNamespace
        {
            get
            {
                return this.rootNamespaceField;
            }
            set
            {
                this.rootNamespaceField = value;
            }
        }

        /// <remarks/>
        public string AssemblyName
        {
            get
            {
                return this.assemblyNameField;
            }
            set
            {
                this.assemblyNameField = value;
            }
        }

        /// <remarks/>
        public string TargetFrameworkVersion
        {
            get
            {
                return this.targetFrameworkVersionField;
            }
            set
            {
                this.targetFrameworkVersionField = value;
            }
        }

        /// <remarks/>
        public bool UseIISExpress
        {
            get
            {
                return this.useIISExpressField;
            }
            set
            {
                this.useIISExpressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UseIISExpressSpecified
        {
            get
            {
                return this.useIISExpressFieldSpecified;
            }
            set
            {
                this.useIISExpressFieldSpecified = value;
            }
        }

        /// <remarks/>
        public object IISExpressSSLPort
        {
            get
            {
                return this.iISExpressSSLPortField;
            }
            set
            {
                this.iISExpressSSLPortField = value;
            }
        }

        /// <remarks/>
        public object IISExpressAnonymousAuthentication
        {
            get
            {
                return this.iISExpressAnonymousAuthenticationField;
            }
            set
            {
                this.iISExpressAnonymousAuthenticationField = value;
            }
        }

        /// <remarks/>
        public object IISExpressWindowsAuthentication
        {
            get
            {
                return this.iISExpressWindowsAuthenticationField;
            }
            set
            {
                this.iISExpressWindowsAuthenticationField = value;
            }
        }

        /// <remarks/>
        public object IISExpressUseClassicPipelineMode
        {
            get
            {
                return this.iISExpressUseClassicPipelineModeField;
            }
            set
            {
                this.iISExpressUseClassicPipelineModeField = value;
            }
        }

        /// <remarks/>
        public object UseGlobalApplicationHostFile
        {
            get
            {
                return this.useGlobalApplicationHostFileField;
            }
            set
            {
                this.useGlobalApplicationHostFileField = value;
            }
        }

        /// <remarks/>
        public object NuGetPackageImportStamp
        {
            get
            {
                return this.nuGetPackageImportStampField;
            }
            set
            {
                this.nuGetPackageImportStampField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectPropertyGroupVisualStudioVersion
    {

        private string conditionField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectPropertyGroupVSToolsPath
    {

        private string conditionField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectPropertyGroupConfiguration
    {

        private string conditionField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectPropertyGroupPlatform
    {

        private string conditionField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectTarget
    {

        private ProjectTargetPropertyGroup propertyGroupField;

        private ProjectTargetError[] errorField;

        private string nameField;

        private string beforeTargetsField;

        /// <remarks/>
        public ProjectTargetPropertyGroup PropertyGroup
        {
            get
            {
                return this.propertyGroupField;
            }
            set
            {
                this.propertyGroupField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Error")]
        public ProjectTargetError[] Error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BeforeTargets
        {
            get
            {
                return this.beforeTargetsField;
            }
            set
            {
                this.beforeTargetsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectTargetPropertyGroup
    {

        private string errorTextField;

        /// <remarks/>
        public string ErrorText
        {
            get
            {
                return this.errorTextField;
            }
            set
            {
                this.errorTextField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class ProjectTargetError
    {

        private string conditionField;

        private string textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }



    #endregion

    #region package.config
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class packages
    {
        private packagesPackage[] packageField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("package")]
        public packagesPackage[] package
        {
            get
            {
                return this.packageField;
            }
            set
            {
                this.packageField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class packagesPackage
    {

        private string idField;

        private string versionField;

        private string targetFrameworkField;

        private bool developmentDependencyField;

        private bool developmentDependencyFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string targetFramework
        {
            get
            {
                return this.targetFrameworkField;
            }
            set
            {
                this.targetFrameworkField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool developmentDependency
        {
            get
            {
                return this.developmentDependencyField;
            }
            set
            {
                this.developmentDependencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool developmentDependencySpecified
        {
            get
            {
                return this.developmentDependencyFieldSpecified;
            }
            set
            {
                this.developmentDependencyFieldSpecified = value;
            }
        }
    }
    #endregion
}
