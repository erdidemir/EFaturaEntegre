namespace EFaturaEntegre
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Invoice));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Invoice)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "CanonicalizationMethod")]
    public class CanonicalizationMethod
    {

        [XmlAttribute(AttributeName = "Algorithm")]
        public string Algorithm;
    }

    [XmlRoot(ElementName = "SignatureMethod")]
    public class SignatureMethod
    {

        [XmlAttribute(AttributeName = "Algorithm")]
        public string Algorithm;
    }

    [XmlRoot(ElementName = "Transform")]
    public class Transform
    {

        [XmlAttribute(AttributeName = "Algorithm")]
        public string Algorithm;
    }

    [XmlRoot(ElementName = "Transforms")]
    public class Transforms
    {

        [XmlElement(ElementName = "Transform")]
        public Transform Transform;
    }

    [XmlRoot(ElementName = "DigestMethod")]
    public class DigestMethod
    {

        [XmlAttribute(AttributeName = "Algorithm")]
        public string Algorithm;
    }

    [XmlRoot(ElementName = "Reference")]
    public class Reference
    {

        [XmlElement(ElementName = "Transforms")]
        public Transforms Transforms;

        [XmlElement(ElementName = "DigestMethod")]
        public DigestMethod DigestMethod;

        [XmlElement(ElementName = "DigestValue")]
        public string DigestValue;

        [XmlAttribute(AttributeName = "URI")]
        public object URI;

        [XmlText]
        public string Text;

        [XmlAttribute(AttributeName = "Id")]
        public string Id;

        [XmlAttribute(AttributeName = "Type")]
        public string Type;
    }

    [XmlRoot(ElementName = "SignedInfo")]
    public class SignedInfo
    {

        [XmlElement(ElementName = "CanonicalizationMethod")]
        public CanonicalizationMethod CanonicalizationMethod;

        [XmlElement(ElementName = "SignatureMethod")]
        public SignatureMethod SignatureMethod;

        [XmlElement(ElementName = "Reference")]
        public List<Reference> Reference;

        [XmlAttribute(AttributeName = "Id")]
        public string Id;

        [XmlText]
        public string Text;
    }

    [XmlRoot(ElementName = "SignatureValue")]
    public class SignatureValue
    {

        [XmlAttribute(AttributeName = "Id")]
        public string Id;

        [XmlText]
        public string Text;
    }

    [XmlRoot(ElementName = "RSAKeyValue")]
    public class RSAKeyValue
    {

        [XmlElement(ElementName = "Modulus")]
        public string Modulus;

        [XmlElement(ElementName = "Exponent")]
        public string Exponent;
    }

    [XmlRoot(ElementName = "KeyValue")]
    public class KeyValue
    {

        [XmlElement(ElementName = "RSAKeyValue")]
        public RSAKeyValue RSAKeyValue;
    }

    [XmlRoot(ElementName = "X509Data")]
    public class X509Data
    {

        [XmlElement(ElementName = "X509SubjectName")]
        public string X509SubjectName;

        [XmlElement(ElementName = "X509Certificate")]
        public string X509Certificate;
    }

    [XmlRoot(ElementName = "KeyInfo")]
    public class KeyInfo
    {

        [XmlElement(ElementName = "KeyValue")]
        public KeyValue KeyValue;

        [XmlElement(ElementName = "X509Data")]
        public X509Data X509Data;
    }

    [XmlRoot(ElementName = "CertDigest")]
    public class CertDigest
    {

        [XmlElement(ElementName = "DigestMethod")]
        public DigestMethod DigestMethod;

        [XmlElement(ElementName = "DigestValue")]
        public string DigestValue;
    }

    [XmlRoot(ElementName = "IssuerSerial")]
    public class IssuerSerial
    {

        [XmlElement(ElementName = "X509IssuerName")]
        public string X509IssuerName;

        [XmlElement(ElementName = "X509SerialNumber")]
        public double X509SerialNumber;
    }

    [XmlRoot(ElementName = "Cert")]
    public class Cert
    {

        [XmlElement(ElementName = "CertDigest")]
        public CertDigest CertDigest;

        [XmlElement(ElementName = "IssuerSerial")]
        public IssuerSerial IssuerSerial;
    }

    [XmlRoot(ElementName = "SigningCertificate")]
    public class SigningCertificate
    {

        [XmlElement(ElementName = "Cert")]
        public Cert Cert;
    }

    [XmlRoot(ElementName = "ClaimedRoles")]
    public class ClaimedRoles
    {

        [XmlElement(ElementName = "ClaimedRole")]
        public string ClaimedRole;
    }

    [XmlRoot(ElementName = "SignerRole")]
    public class SignerRole
    {

        [XmlElement(ElementName = "ClaimedRoles")]
        public ClaimedRoles ClaimedRoles;
    }

    [XmlRoot(ElementName = "SignedSignatureProperties")]
    public class SignedSignatureProperties
    {

        [XmlElement(ElementName = "SigningTime")]
        public DateTime SigningTime;

        [XmlElement(ElementName = "SigningCertificate")]
        public SigningCertificate SigningCertificate;

        [XmlElement(ElementName = "SignerRole")]
        public SignerRole SignerRole;
    }

    [XmlRoot(ElementName = "SignedProperties")]
    public class SignedProperties
    {

        [XmlElement(ElementName = "SignedSignatureProperties")]
        public SignedSignatureProperties SignedSignatureProperties;

        [XmlAttribute(AttributeName = "Id")]
        public string Id;

        [XmlText]
        public string Text;
    }

    [XmlRoot(ElementName = "QualifyingProperties")]
    public class QualifyingProperties
    {

        [XmlElement(ElementName = "SignedProperties")]
        public SignedProperties SignedProperties;

        [XmlAttribute(AttributeName = "Target")]
        public string Target;

        [XmlText]
        public string Text;
    }

    [XmlRoot(ElementName = "Object")]
    public class Object
    {

        [XmlElement(ElementName = "QualifyingProperties")]
        public QualifyingProperties QualifyingProperties;
    }

    [XmlRoot(ElementName = "Signature")]
    public class Signature
    {

        [XmlElement(ElementName = "SignedInfo")]
        public SignedInfo SignedInfo;

        [XmlElement(ElementName = "SignatureValue")]
        public SignatureValue SignatureValue;

        [XmlElement(ElementName = "KeyInfo")]
        public KeyInfo KeyInfo;

        [XmlElement(ElementName = "Object")]
        public Object Object;

        [XmlAttribute(AttributeName = "Id")]
        public string Id;

        [XmlText]
        public string Text;

        [XmlElement(ElementName = "ID")]
        public ID ID;

        [XmlElement(ElementName = "SignatoryParty")]
        public SignatoryParty SignatoryParty;

        [XmlElement(ElementName = "DigitalSignatureAttachment")]
        public DigitalSignatureAttachment DigitalSignatureAttachment;
    }

    [XmlRoot(ElementName = "ExtensionContent")]
    public class ExtensionContent
    {

        [XmlElement(ElementName = "Signature")]
        public Signature Signature;
    }

    [XmlRoot(ElementName = "UBLExtension")]
    public class UBLExtension
    {

        [XmlElement(ElementName = "ExtensionContent")]
        public ExtensionContent ExtensionContent;
    }

    [XmlRoot(ElementName = "UBLExtensions")]
    public class UBLExtensions
    {

        [XmlElement(ElementName = "UBLExtension")]
        public UBLExtension UBLExtension;
    }

    [XmlRoot(ElementName = "DocumentCurrencyCode")]
    public class DocumentCurrencyCode
    {

        [XmlAttribute(AttributeName = "listAgencyName")]
        public string ListAgencyName;

        [XmlAttribute(AttributeName = "listID")]
        public string ListID;

        [XmlAttribute(AttributeName = "listName")]
        public string ListName;

        [XmlAttribute(AttributeName = "listVersionID")]
        public int ListVersionID;

        [XmlText]
        public string Text;
    }

    [XmlRoot(ElementName = "EmbeddedDocumentBinaryObject")]
    public class EmbeddedDocumentBinaryObject
    {

        [XmlAttribute(AttributeName = "characterSetCode")]
        public string CharacterSetCode;

        [XmlAttribute(AttributeName = "encodingCode")]
        public string EncodingCode;

        [XmlAttribute(AttributeName = "filename")]
        public string Filename;

        [XmlAttribute(AttributeName = "mimeCode")]
        public string MimeCode;

        [XmlText]
        public string Text;
    }

    [XmlRoot(ElementName = "Attachment")]
    public class Attachment
    {

        [XmlElement(ElementName = "EmbeddedDocumentBinaryObject")]
        public EmbeddedDocumentBinaryObject EmbeddedDocumentBinaryObject;
    }

    [XmlRoot(ElementName = "AdditionalDocumentReference")]
    public class AdditionalDocumentReference
    {

        [XmlElement(ElementName = "ID")]
        public string ID;

        [XmlElement(ElementName = "IssueDate")]
        public DateTime IssueDate;

        [XmlElement(ElementName = "Attachment")]
        public Attachment Attachment;
    }

    [XmlRoot(ElementName = "ID")]
    public class ID
    {

        [XmlAttribute(AttributeName = "schemeID")]
        public string SchemeID;

        [XmlText]
        public double Text;
    }

    [XmlRoot(ElementName = "PartyIdentification")]
    public class PartyIdentification
    {

        [XmlElement(ElementName = "ID")]
        public ID ID;
    }

    [XmlRoot(ElementName = "Country")]
    public class Country
    {

        [XmlElement(ElementName = "Name")]
        public string Name;
    }

    [XmlRoot(ElementName = "PostalAddress")]
    public class PostalAddress
    {

        [XmlElement(ElementName = "Room")]
        public int Room;

        [XmlElement(ElementName = "StreetName")]
        public string StreetName;

        [XmlElement(ElementName = "BuildingName")]
        public string BuildingName;

        [XmlElement(ElementName = "BuildingNumber")]
        public int BuildingNumber;

        [XmlElement(ElementName = "CitySubdivisionName")]
        public string CitySubdivisionName;

        [XmlElement(ElementName = "CityName")]
        public string CityName;

        [XmlElement(ElementName = "PostalZone")]
        public int PostalZone;

        [XmlElement(ElementName = "Region")]
        public string Region;

        [XmlElement(ElementName = "Country")]
        public Country Country;
    }

    [XmlRoot(ElementName = "SignatoryParty")]
    public class SignatoryParty
    {

        [XmlElement(ElementName = "PartyIdentification")]
        public PartyIdentification PartyIdentification;

        [XmlElement(ElementName = "PostalAddress")]
        public PostalAddress PostalAddress;
    }

    [XmlRoot(ElementName = "ExternalReference")]
    public class ExternalReference
    {

        [XmlElement(ElementName = "URI")]
        public string URI;
    }

    [XmlRoot(ElementName = "DigitalSignatureAttachment")]
    public class DigitalSignatureAttachment
    {

        [XmlElement(ElementName = "ExternalReference")]
        public ExternalReference ExternalReference;
    }

    [XmlRoot(ElementName = "PartyName")]
    public class PartyName
    {

        [XmlElement(ElementName = "Name")]
        public string Name;
    }

    [XmlRoot(ElementName = "TaxScheme")]
    public class TaxScheme
    {

        [XmlElement(ElementName = "Name")]
        public string Name;

        [XmlElement(ElementName = "TaxTypeCode")]
        public int TaxTypeCode;
    }

    [XmlRoot(ElementName = "PartyTaxScheme")]
    public class PartyTaxScheme
    {

        [XmlElement(ElementName = "TaxScheme")]
        public TaxScheme TaxScheme;
    }

    [XmlRoot(ElementName = "Contact")]
    public class Contact
    {

        [XmlElement(ElementName = "Telephone")]
        public double Telephone;

        [XmlElement(ElementName = "Telefax")]
        public double Telefax;

        [XmlElement(ElementName = "ElectronicMail")]
        public string ElectronicMail;
    }

    [XmlRoot(ElementName = "Party")]
    public class Party
    {

        [XmlElement(ElementName = "PartyIdentification")]
        public PartyIdentification PartyIdentification;

        [XmlElement(ElementName = "PartyName")]
        public PartyName PartyName;

        [XmlElement(ElementName = "PostalAddress")]
        public PostalAddress PostalAddress;

        [XmlElement(ElementName = "PartyTaxScheme")]
        public PartyTaxScheme PartyTaxScheme;

        [XmlElement(ElementName = "Contact")]
        public Contact Contact;
    }

    [XmlRoot(ElementName = "AccountingSupplierParty")]
    public class AccountingSupplierParty
    {

        [XmlElement(ElementName = "Party")]
        public Party Party;
    }

    [XmlRoot(ElementName = "AccountingCustomerParty")]
    public class AccountingCustomerParty
    {

        [XmlElement(ElementName = "Party")]
        public Party Party;
    }

    [XmlRoot(ElementName = "TaxAmount")]
    public class TaxAmount
    {

        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID;

        [XmlText]
        public double Text;
    }

    [XmlRoot(ElementName = "TaxableAmount")]
    public class TaxableAmount
    {

        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID;

        [XmlText]
        public double Text;
    }

    [XmlRoot(ElementName = "TaxCategory")]
    public class TaxCategory
    {

        [XmlElement(ElementName = "TaxScheme")]
        public TaxScheme TaxScheme;
    }

    [XmlRoot(ElementName = "TaxSubtotal")]
    public class TaxSubtotal
    {

        [XmlElement(ElementName = "TaxableAmount")]
        public TaxableAmount TaxableAmount;

        [XmlElement(ElementName = "TaxAmount")]
        public TaxAmount TaxAmount;

        [XmlElement(ElementName = "CalculationSequenceNumeric")]
        public int CalculationSequenceNumeric;

        [XmlElement(ElementName = "Percent")]
        public int Percent;

        [XmlElement(ElementName = "TaxCategory")]
        public TaxCategory TaxCategory;
    }

    [XmlRoot(ElementName = "TaxTotal")]
    public class TaxTotal
    {

        [XmlElement(ElementName = "TaxAmount")]
        public TaxAmount TaxAmount;

        [XmlElement(ElementName = "TaxSubtotal")]
        public TaxSubtotal TaxSubtotal;
    }

    [XmlRoot(ElementName = "LineExtensionAmount")]
    public class LineExtensionAmount
    {

        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID;

        [XmlText]
        public double Text;
    }

    [XmlRoot(ElementName = "TaxExclusiveAmount")]
    public class TaxExclusiveAmount
    {

        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID;

        [XmlText]
        public double Text;
    }

    [XmlRoot(ElementName = "TaxInclusiveAmount")]
    public class TaxInclusiveAmount
    {

        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID;

        [XmlText]
        public DateTime Text;
    }

    [XmlRoot(ElementName = "AllowanceTotalAmount")]
    public class AllowanceTotalAmount
    {

        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID;

        [XmlText]
        public double Text;
    }

    [XmlRoot(ElementName = "PayableAmount")]
    public class PayableAmount
    {

        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID;

        [XmlText]
        public DateTime Text;
    }

    [XmlRoot(ElementName = "LegalMonetaryTotal")]
    public class LegalMonetaryTotal
    {

        [XmlElement(ElementName = "LineExtensionAmount")]
        public LineExtensionAmount LineExtensionAmount;

        [XmlElement(ElementName = "TaxExclusiveAmount")]
        public TaxExclusiveAmount TaxExclusiveAmount;

        [XmlElement(ElementName = "TaxInclusiveAmount")]
        public TaxInclusiveAmount TaxInclusiveAmount;

        [XmlElement(ElementName = "AllowanceTotalAmount")]
        public AllowanceTotalAmount AllowanceTotalAmount;

        [XmlElement(ElementName = "PayableAmount")]
        public PayableAmount PayableAmount;
    }

    [XmlRoot(ElementName = "InvoicedQuantity")]
    public class InvoicedQuantity
    {

        [XmlAttribute(AttributeName = "unitCode")]
        public string UnitCode;

        [XmlText]
        public int Text;
    }

    [XmlRoot(ElementName = "Item")]
    public class Item
    {

        [XmlElement(ElementName = "Name")]
        public string Name;
    }

    [XmlRoot(ElementName = "PriceAmount")]
    public class PriceAmount
    {

        [XmlAttribute(AttributeName = "currencyID")]
        public string CurrencyID;

        [XmlText]
        public int Text;
    }

    [XmlRoot(ElementName = "Price")]
    public class Price
    {

        [XmlElement(ElementName = "PriceAmount")]
        public PriceAmount PriceAmount;
    }

    [XmlRoot(ElementName = "InvoiceLine")]
    public class InvoiceLine
    {

        [XmlElement(ElementName = "ID")]
        public int ID;

        [XmlElement(ElementName = "InvoicedQuantity")]
        public InvoicedQuantity InvoicedQuantity;

        [XmlElement(ElementName = "LineExtensionAmount")]
        public LineExtensionAmount LineExtensionAmount;

        [XmlElement(ElementName = "TaxTotal")]
        public TaxTotal TaxTotal;

        [XmlElement(ElementName = "Item")]
        public Item Item;

        [XmlElement(ElementName = "Price")]
        public Price Price;
    }

    [XmlRoot(ElementName = "Invoice")]
    public class Invoice
    {

        [XmlElement(ElementName = "UBLExtensions")]
        public UBLExtensions UBLExtensions;

        [XmlElement(ElementName = "UBLVersionID")]
        public double UBLVersionID;

        [XmlElement(ElementName = "CustomizationID")]
        public string CustomizationID;

        [XmlElement(ElementName = "ProfileID")]
        public string ProfileID;

        [XmlElement(ElementName = "ID")]
        public string ID;

        [XmlElement(ElementName = "CopyIndicator")]
        public bool CopyIndicator;

        [XmlElement(ElementName = "UUID")]
        public string UUID;

        [XmlElement(ElementName = "IssueDate")]
        public DateTime IssueDate;

        [XmlElement(ElementName = "InvoiceTypeCode")]
        public string InvoiceTypeCode;

        [XmlElement(ElementName = "Note")]
        public string Note;

        [XmlElement(ElementName = "DocumentCurrencyCode")]
        public DocumentCurrencyCode DocumentCurrencyCode;

        [XmlElement(ElementName = "LineCountNumeric")]
        public int LineCountNumeric;

        [XmlElement(ElementName = "AdditionalDocumentReference")]
        public AdditionalDocumentReference AdditionalDocumentReference;

        [XmlElement(ElementName = "Signature")]
        public Signature Signature;

        [XmlElement(ElementName = "AccountingSupplierParty")]
        public AccountingSupplierParty AccountingSupplierParty;

        [XmlElement(ElementName = "AccountingCustomerParty")]
        public AccountingCustomerParty AccountingCustomerParty;

        [XmlElement(ElementName = "TaxTotal")]
        public TaxTotal TaxTotal;

        [XmlElement(ElementName = "LegalMonetaryTotal")]
        public LegalMonetaryTotal LegalMonetaryTotal;

        [XmlElement(ElementName = "InvoiceLine")]
        public InvoiceLine InvoiceLine;

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns;

        [XmlAttribute(AttributeName = "cac")]
        public string Cac;

        [XmlAttribute(AttributeName = "xades")]
        public string Xades;

        [XmlAttribute(AttributeName = "udt")]
        public string Udt;

        [XmlAttribute(AttributeName = "cbc")]
        public string Cbc;

        [XmlAttribute(AttributeName = "ccts")]
        public string Ccts;

        [XmlAttribute(AttributeName = "ubltr")]
        public string Ubltr;

        [XmlAttribute(AttributeName = "qdt")]
        public string Qdt;

        [XmlAttribute(AttributeName = "ext")]
        public string Ext;

        [XmlAttribute(AttributeName = "ds")]
        public string Ds;

        [XmlAttribute(AttributeName = "xsi")]
        public string Xsi;

        [XmlAttribute(AttributeName = "schemaLocation")]
        public string SchemaLocation;

        [XmlText]
        public string Text;
    }


}