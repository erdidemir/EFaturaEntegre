using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;

public class EFatura
{
    public StandardBusinessDocument GetFatura()
    {
        // Örnek bir StandardBusinessDocument oluþtur
        StandardBusinessDocument sbd = new StandardBusinessDocument
        {
            StandardBusinessDocumentHeader = new StandardBusinessDocumentHeader
            {
                // Header bilgilerini doldur
                // Örnek veri ile dolduruldu, gerçek verilerle deðiþtirilmeli
                HeaderVersion = 1.0,
                Sender = new Sender
                {
                    Identifier = "SenderIdentifier",
                    ContactInformation = new List<ContactInformation>
                    {
                        new ContactInformation
                        {
                            Contact = "SenderContact",
                            ContactTypeIdentifier = "SenderContactType"
                        }
                    }
                },
                Receiver = new Receiver
                {
                    Identifier = "ReceiverIdentifier",
                    ContactInformation = new List<ContactInformation>
                    {
                        new ContactInformation
                        {
                            Contact = "ReceiverContact",
                            ContactTypeIdentifier = "ReceiverContactType"
                        }
                    }
                },
                DocumentIdentification = new DocumentIdentification
                {
                    Standard = "ExampleStandard",
                    TypeVersion = 1.0,
                    InstanceIdentifier = Guid.NewGuid().ToString(),
                    Type = "ExampleType",
                    CreationDateAndTime = DateTime.UtcNow
                }
            },
            Package = new Package
            {
                Elements = new Elements
                {
                    ElementType = "ExampleElementType",
                    ElementCount = 1,
                    ElementList = new ElementList
                    {
                        Invoice = new Invoice
                        {
                            // Fatura bilgilerini doldur
                            // Örnek veri ile dolduruldu, gerçek verilerle deðiþtirilmeli
                            UBLVersionID = 2.1,
                            CustomizationID = "CustomizationID",
                            ProfileID = "ProfileID",
                            ID = "InvoiceID",
                            CopyIndicator = false,
                            UUID = Guid.NewGuid().ToString(),
                            IssueDate = DateTime.UtcNow,
                            InvoiceTypeCode = "InvoiceType",
                            Note = "Example note",
                            DocumentCurrencyCode = new DocumentCurrencyCode
                            {
                                ListAgencyName = "CurrencyListAgency",
                                ListID = "CurrencyListID",
                                ListName = "CurrencyListName",
                                ListVersionID = 1,
                                Text = "USD"
                            },
                            LineCountNumeric = 1,
                            // Diðer fatura detaylarý buraya eklenmeli
                            // Bu sadece örnek bir veridir
                            InvoiceLine = new InvoiceLine
                            {
                                ID = 1,
                                InvoicedQuantity = new InvoicedQuantity
                                {
                                    UnitCode = "UnitCode",
                                    Text = 1
                                },
                                LineExtensionAmount = new LineExtensionAmount
                                {
                                    CurrencyID = "USD",
                                    Text = 100
                                },
                                // Diðer detaylar buraya eklenecek
                                // Örnek veri ile dolduruldu, gerçek verilerle deðiþtirilmeli
                                Item = new Item
                                {
                                    Name = "ItemName"
                                },
                                Price = new Price
                                {
                                    PriceAmount = new PriceAmount
                                    {
                                        CurrencyID = "USD",
                                        Text = 100
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };

        return sbd;
    }


    public void GetFatura2(StandardBusinessDocument standardBusinessDocument)
    {
        // XML belgesi oluþturma
        XmlDocument xmlDoc = new XmlDocument();

        // Kök öðe oluþturma
        XmlElement root = xmlDoc.CreateElement("sh:StandardBusinessDocument");
        xmlDoc.AppendChild(root);

        // xsi, sh, ef isim alanlarýný ekleyin
        XmlAttribute xsiAttr = xmlDoc.CreateAttribute("xmlns:xsi");
        xsiAttr.Value = "http://www.w3.org/2001/XMLSchema-instance";
        root.Attributes.Append(xsiAttr);

        XmlAttribute schemaLocAttr = xmlDoc.CreateAttribute("xsi:schemaLocation");
        schemaLocAttr.Value = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader PackageProxy_1_2.xsd";
        root.Attributes.Append(schemaLocAttr);

        XmlAttribute shAttr = xmlDoc.CreateAttribute("xmlns:sh");
        shAttr.Value = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader";
        root.Attributes.Append(shAttr);

        XmlAttribute efAttr = xmlDoc.CreateAttribute("xmlns:ef");
        efAttr.Value = "http://www.efatura.gov.tr/package-namespace";
        root.Attributes.Append(efAttr);

        #region <sh:StandardBusinessDocumentHeader>

        // StandardBusinessDocumentHeader öðesini oluþturma
        XmlElement header = xmlDoc.CreateElement("sh:StandardBusinessDocumentHeader");
        root.AppendChild(header);

        // Sender öðesini oluþturma
        XmlElement sender = xmlDoc.CreateElement("sh:Sender");
        header.AppendChild(sender);

        // Sender'ýn Identifier öðesini oluþturma
        XmlElement senderIdentifier = xmlDoc.CreateElement("sh:Identifier");
        senderIdentifier.InnerText = "urn:mail:defaultgb@gib.gov.tr";
        sender.AppendChild(senderIdentifier);

        // Sender'ýn ContactInformation öðelerini oluþturma
        XmlElement senderContactInfo1 = xmlDoc.CreateElement("sh:ContactInformation");
        sender.AppendChild(senderContactInfo1);

        XmlElement senderContact1 = xmlDoc.CreateElement("sh:Contact");
        senderContact1.InnerText = "e-Fatura Deneme A.Þ.";
        senderContactInfo1.AppendChild(senderContact1);

        XmlElement senderContactType1 = xmlDoc.CreateElement("sh:ContactTypeIdentifier");
        senderContactType1.InnerText = "UNVAN";
        senderContactInfo1.AppendChild(senderContactType1);

        XmlElement senderContactInfo2 = xmlDoc.CreateElement("sh:ContactInformation");
        sender.AppendChild(senderContactInfo2);

        XmlElement senderContact2 = xmlDoc.CreateElement("sh:Contact");
        senderContact2.InnerText = "9999999999";
        senderContactInfo2.AppendChild(senderContact2);

        XmlElement senderContactType2 = xmlDoc.CreateElement("sh:ContactTypeIdentifier");
        senderContactType2.InnerText = "VKN_TCKN";
        senderContactInfo2.AppendChild(senderContactType2);

        // Receiver öðesini oluþturma (Sender ile benzer þekilde)
        XmlElement receiver = xmlDoc.CreateElement("sh:Receiver");
        header.AppendChild(receiver);

        // DocumentIdentification öðesini oluþturma
        XmlElement docIdentification = xmlDoc.CreateElement("sh:DocumentIdentification");
        header.AppendChild(docIdentification);

        #endregion


        // DocumentIdentification'ýn alt öðelerini oluþturma
        XmlElement standard = xmlDoc.CreateElement("sh:Standard");
        docIdentification.AppendChild(standard);

        XmlElement typeVersion = xmlDoc.CreateElement("sh:TypeVersion");
        typeVersion.InnerText = "1.0";
        docIdentification.AppendChild(typeVersion);

        XmlElement instanceIdentifier = xmlDoc.CreateElement("sh:InstanceIdentifier");
        instanceIdentifier.InnerText = "e002da78-223f-438c-addb-16badeb047b5";
        docIdentification.AppendChild(instanceIdentifier);

        XmlElement type = xmlDoc.CreateElement("sh:Type");
        type.InnerText = "SENDERENVELOPE";
        docIdentification.AppendChild(type);

        XmlElement creationDateAndTime = xmlDoc.CreateElement("sh:CreationDateAndTime");
        creationDateAndTime.InnerText = "2013-06-19T14:47:55";
        docIdentification.AppendChild(creationDateAndTime);

        // Package öðesini oluþturma
        XmlElement package = xmlDoc.CreateElement("ef:Package");
        root.AppendChild(package);

        // Package'ýn alt öðelerini oluþturma
        XmlElement elements = xmlDoc.CreateElement("Elements");
        package.AppendChild(elements);

        XmlElement elementType = xmlDoc.CreateElement("ElementType");
        elementType.InnerText = "INVOICE";
        elements.AppendChild(elementType);

        XmlElement elementCount = xmlDoc.CreateElement("ElementCount");
        elementCount.InnerText = "1";
        elements.AppendChild(elementCount);

        XmlElement elementList = xmlDoc.CreateElement("ElementList");
        elements.AppendChild(elementList);

        // Invoice öðesini oluþturma
        XmlElement invoice = xmlDoc.CreateElement("Invoice", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
        invoice.SetAttribute("xmlns:cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
        // ... Diðer namespace'leri ve attribute'leri buraya ekleyebilirsiniz ...

        elementList.AppendChild(invoice);

        // Invoice'ýn alt öðelerini oluþturma

        // ext:UBLExtensions öðesi
        XmlElement ublExtensions = xmlDoc.CreateElement("ext:UBLExtensions");
        invoice.AppendChild(ublExtensions);

        // ext:UBLExtension öðesi
        XmlElement ublExtension = xmlDoc.CreateElement("ext:UBLExtension");
        ublExtensions.AppendChild(ublExtension);

        // ext:ExtensionContent öðesi
        XmlElement extensionContent = xmlDoc.CreateElement("ext:ExtensionContent");
        ublExtension.AppendChild(extensionContent);

        // ds:Signature öðesi
        XmlElement signature = xmlDoc.CreateElement("ds:Signature", "http://www.w3.org/2000/09/xmldsig#");
        extensionContent.AppendChild(signature);

        // ds:SignedInfo öðesi
        XmlElement signedInfo = xmlDoc.CreateElement("ds:SignedInfo");
        signature.AppendChild(signedInfo);

        // ds:CanonicalizationMethod öðesi
        XmlElement canonicalizationMethod = xmlDoc.CreateElement("ds:CanonicalizationMethod");
        canonicalizationMethod.SetAttribute("Algorithm", "http://www.w3.org/TR/2001/REC-xml-c14n-20010315#WithComments");
        signedInfo.AppendChild(canonicalizationMethod);

        // ds:SignatureMethod öðesi
        XmlElement signatureMethod = xmlDoc.CreateElement("ds:SignatureMethod");
        signatureMethod.SetAttribute("Algorithm", "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");
        signedInfo.AppendChild(signatureMethod);

        // ds:Reference öðesi
        XmlElement reference = xmlDoc.CreateElement("ds:Reference");
        reference.SetAttribute("URI", "");
        signedInfo.AppendChild(reference);

        // ... ds:Reference alt öðeleri buraya eklenmeli (ds:DigestMethod, ds:Transforms, ds:DigestValue) ...

        // ds:SignatureValue öðesi
        XmlElement signatureValue = xmlDoc.CreateElement("ds:SignatureValue");
        signatureValue.SetAttribute("Id", "id1");
        signatureValue.InnerText = "..."; // Buraya imza deðerini eklemelisiniz
        signature.AppendChild(signatureValue);

        // ds:KeyInfo öðesi
        XmlElement keyInfo = xmlDoc.CreateElement("ds:KeyInfo");
        signature.AppendChild(keyInfo);

        // ... ds:KeyInfo alt öðeleri buraya eklenmeli (ds:KeyValue, ds:X509Data) ...

        // ds:Object öðesi
        XmlElement obj = xmlDoc.CreateElement("ds:Object");
        signature.AppendChild(obj);

        // xades:QualifyingProperties öðesi
        XmlElement qualifyingProps = xmlDoc.CreateElement("xades:QualifyingProperties");
        qualifyingProps.SetAttribute("Target", "#Signature_TST2013000000766");
        obj.AppendChild(qualifyingProps);

        // xades:SignedProperties öðesi
        XmlElement signedProps = xmlDoc.CreateElement("xades:SignedProperties");
        signedProps.SetAttribute("Id", "SignedProperties");
        qualifyingProps.AppendChild(signedProps);

        // xades:SignedSignatureProperties öðesi
        XmlElement signedSigProps = xmlDoc.CreateElement("xades:SignedSignatureProperties");
        signedProps.AppendChild(signedSigProps);

        // xades:SigningTime öðesi
        XmlElement signingTime = xmlDoc.CreateElement("xades:SigningTime");
        signingTime.InnerText = "2013-06-19T14:47:55.311+03:00";
        signedSigProps.AppendChild(signingTime);

        // xades:SigningCertificate öðesi
        // ... Diðer alt öðeleri buraya eklemelisiniz ...

        // xades:SignerRole öðesi
        XmlElement signerRole = xmlDoc.CreateElement("xades:SignerRole");
        signedSigProps.AppendChild(signerRole);

        // xades:ClaimedRoles öðesi
        XmlElement claimedRoles = xmlDoc.CreateElement("xades:ClaimedRoles");
        signerRole.AppendChild(claimedRoles);

        // xades:ClaimedRole öðesi
        XmlElement claimedRole = xmlDoc.CreateElement("xades:ClaimedRole");
        claimedRole.InnerText = "Tedarikçi";
        claimedRoles.AppendChild(claimedRole);

        // Diðer alt öðelerin eklenmesi...

        // ds:Reference alt öðeleri
        XmlElement transforms = xmlDoc.CreateElement("ds:Transforms");
        XmlElement transform = xmlDoc.CreateElement("ds:Transform");
        transform.SetAttribute("Algorithm", "http://www.w3.org/2000/09/xmldsig#enveloped-signature");
        transforms.AppendChild(transform);
        reference.AppendChild(transforms);

        XmlElement digestMethod = xmlDoc.CreateElement("ds:DigestMethod");
        digestMethod.SetAttribute("Algorithm", "http://www.w3.org/2001/04/xmlenc#sha256");
        reference.AppendChild(digestMethod);

        XmlElement digestValue = xmlDoc.CreateElement("ds:DigestValue");
        digestValue.InnerText = "mlTwy1zNm4dBEo1Q/97X9gBxOn0tIfsMKFzb++8RmGA="; // Buraya digest deðerini ekleyin
        reference.AppendChild(digestValue);

        // ds:KeyInfo alt öðeleri
        XmlElement keyValue = xmlDoc.CreateElement("ds:KeyValue");
        XmlElement rsaKeyValue = xmlDoc.CreateElement("ds:RSAKeyValue");
        keyValue.AppendChild(rsaKeyValue);
        keyInfo.AppendChild(keyValue);

        // Burada RSA Key Value alt öðeleri (ds:Modulus ve ds:Exponent) eklenmelidir
        // Modulus ve Exponent deðerlerini kendi kullaným durumunuza göre eklemelisiniz

        XmlElement modulus = xmlDoc.CreateElement("ds:Modulus");
        modulus.InnerText = "g4fWV5+GRbNQTnVpG5naG/4xC167blIngQJdOJVss7LSBjFkOOitvJtpV0Qvsld1HzW9A+P8aR17KdgZzqsc5+akR0+volN2ZH9M+q0Xza7zSQjgBzovv2R6VQWLnEyFb4i3PzEqQMDbF8n30oNWj0BjBvNn+eTkxmk8ifhLDAwrrDasje5CudTNo9pIv73VcJqA3F+pKwW7MGIZeDJpLnbbqz+ELOIR3ev51Ewb889QQyqlMiu2LKaDVmpsFzAlFo25ayLTJ896/cL0Lff+/W+CKeOo3f/SrAcZWp0RWmiKZDET9LqCodeH+2x3M8+KK2IwjABk378e8/TipjfENQ==";
        rsaKeyValue.AppendChild(modulus);

        XmlElement exponent = xmlDoc.CreateElement("ds:Exponent");
        exponent.InnerText = "AQAB";
        rsaKeyValue.AppendChild(exponent);

        // ds:X509Data alt öðeleri
        XmlElement x509Data = xmlDoc.CreateElement("ds:X509Data");
        XmlElement x509SubjectName = xmlDoc.CreateElement("ds:X509SubjectName");
        x509SubjectName.InnerText = "CN=e-Fatura Deneme A.Þ.,2.5.4.5=#130a39393939393939393939,OU=e-Fatura Deneme A.Þ.";
        x509Data.AppendChild(x509SubjectName);

        XmlElement x509Certificate = xmlDoc.CreateElement("ds:X509Certificate");
        x509Certificate.InnerText = "MIIFrDCCBJSgAwIBAgIGAJpaGcRq..."; // Buraya sertifika deðerini ekleyin
        x509Data.AppendChild(x509Certificate);

        keyInfo.AppendChild(x509Data);

        // ds:Object alt öðeleri
        XmlElement certObj = xmlDoc.CreateElement("xades:Certificate");
        // ... Diðer alt öðeleri buraya eklemelisiniz ...

        obj.AppendChild(certObj);

        // Diðer alt öðelerinizi ekleyin...

        // Son olarak XML'i konsola yazdýrma
        Console.WriteLine(xmlDoc.OuterXml);


        // XML'i konsola yazdýrma
        Console.WriteLine(xmlDoc.OuterXml);



        // Diðer öðeleri ekleyin...

        // Örnek XML'i konsola yazdýrma
        Console.WriteLine(xmlDoc.OuterXml);
    }
}
