<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GoogleVision.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Integration With Google Vision API</title>
    <link href="../assets/css/style.css" rel="stylesheet" />
    <style>
        #upload-photo {
            height: 0;
            width: 0;
        }

        #upload-photo-label {
            border: 1px solid #cccccc;
            padding: 5px 30px;
            font-family: arial;
            font-size: 13px;
        }

            #upload-photo-label:active {
                background: #ccc;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="POST">
        <div style="width: 90%; margin: 0 auto;">
            <h1>Integration With Google Vision API</h1>

            <fieldset class="ws-servicos">
                <legend>Informations of Service</legend>
                <table class="registros-exibir">
                    <tr>
                        <td width="40%" align="right">
                            <p class="destaque">Type of Analyse: </p>
                        </td>
                        <td width="60%">
                            <p>
                                <asp:DropDownList ID="ddlType" runat="server" Width="285" />
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            <p class="destaque">Archive: </p>
                        </td>
                        <td width="60%">
                            <p>
                                <input type="file" required="required" id="upload-photo" name="Archive" multiple="multiple" accept="image/*" />
                                <label id="upload-photo-label" for="upload-photo">Find File</label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td width="35%" align="right"></td>
                        <td width="65%" align="right">
                            <p>
                                <input type="submit" name="btnAcao" value="Analyse Image" class="btnSubmitService" />
                            </p>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset class="ws-servicos">
                <legend>Request</legend>
                <fieldset class="ws-resultados">
                    <legend>Image Analysed</legend>
                    <img width="100%" src="PATH  IMAGE" />
                    <div class="ws-xml">                        
                    </div>
                </fieldset>
                <fieldset class="ws-resultados" style="height: 393px;">
                    <legend>Response</legend>
                    <div class="ws-xml">
                       <textarea class="ws-xml-textarea"><%if (Text != null){%><%foreach (var item in Text){Response.Write(item + Environment.NewLine);}%><%}%></textarea>
                    </div>
                </fieldset>
            </fieldset>
        </div>
    </form>
</body>
</html>
