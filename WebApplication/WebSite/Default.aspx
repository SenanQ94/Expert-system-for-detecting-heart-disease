<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        @import url('https://fonts.googleapis.com/css?family=Cairo');

        *{
    
            font-family: 'Cairo', sans-serif;
            text-rendering: optimizeLegibility;
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
   
        }

        .input{

               box-sizing: border-box;
                height: 40px;
                margin-bottom: 0px;
                resize: none;
                 background-color: white;
                width: 150px;
    
                border: 1px solid #999;
                border-radius: 10px;
                margin: 8px 20px;
                direction: ltr;
                padding: 5px 20px;
                padding-left:20px;
   
            }

        .cta{
    width: 150px;
    height: 30px;
    margin: 10px;
    border-radius: 30px;
    border: none;
    background-color: #253342;
    color: white;
    font-size: 100%;
    box-shadow: 0 5px #999;
    cursor: pointer;
    transition-duration: 0.04s;
}

        .cta:active{
                box-shadow: 0 0 #666;
                transform: translateY(5px);
            }

        .auto-style3 {
            width: 553px;
            text-align: right;
            background-color: #00FFFF;
        }
        .auto-style35 {
            color: #000099;
        }

        body
{
   padding: 0;
   margin:0;
   min-width: 900px;
   color: #292929;
    text-align: center;
}

.clearfix:before, .clearfix:after {
   content: "";
   display: table;
}

.clearfix:after {
   clear: both;
}

.cleared {
   font: 0/0 serif;
   clear: both;
}

form
{
   padding: 0 !important;
   margin: 0 !important;
}

table.position
{
   position: relative;
   width: 100%;
   table-layout: fixed;
    margin: 0;
   padding: 0;
}
h1
{
   margin: 0;
   padding: 0;
}
        .auto-style37 {
            width: 216px;
            font-weight: bold;
            background-color: #00FFCC;
            height: 54px;
            text-align: center;
        }
        .auto-style45 {
            width: 100%;
            height: 350px;
            padding-bottom:0;
            margin:0;
        }
        
   
        .auto-style49 {
            margin-right: 402px;
        }

   
        .auto-style51 {
            width: 100%;
            height: 309px;
        }
        .auto-style52 {
            text-align: right;
            background-color: #00FFFF;
            height: 37px;
        }
        .auto-style53 {
            width: 761px;
            text-align: center;
            background-color: #00FFFF;
            height: 50px;
        }
        .auto-style54 {
            width: 871px;
            text-align: center;
            background-color: #00FFFF;
            height: 50px;
        }
        .auto-style55 {
            width: 265px;
            font-weight: bold;
            background-color: #00FFCC;
            height: 50px;
            text-align: center;
            font-style: italic;
        }
        .auto-style56 {
            width: 761px;
            text-align: center;
            background-color: #00FFFF;
            height: 21px;
        }
        .auto-style57 {
            width: 871px;
            text-align: center;
            background-color: #00FFFF;
            height: 21px;
        }
        .auto-style58 {
            width: 265px;
            font-weight: bold;
            background-color: #00FFCC;
            text-align: center;
            font-style: italic;
        }
        .auto-style59 {
            width: 761px;
            text-align: center;
            background-color: #00FFFF;
            height: 19px;
        }
        .auto-style60 {
            width: 871px;
            text-align: center;
            background-color: #00FFFF;
            height: 19px;
        }
        .auto-style61 {
            width: 265px;
            font-weight: bold;
            background-color: #00FFCC;
            height: 19px;
            text-align: center;
            font-style: italic;
        }
        .auto-style62 {
            width: 761px;
            text-align: center;
            background-color: #00FFFF;
            height: 42px;
        }
        .auto-style63 {
            width: 871px;
            text-align: center;
            background-color: #00FFFF;
            height: 42px;
        }
        .auto-style64 {
            width: 265px;
            font-weight: bold;
            background-color: #00FFCC;
            height: 84px;
            text-align: center;
            font-style: italic;
        }
        .auto-style65 {
            width: 761px;
            text-align: center;
            background-color: #00FFFF;
            height: 41px;
        }
        .auto-style66 {
            width: 871px;
            text-align: center;
            background-color: #00FFFF;
            height: 41px;
        }
        .auto-style67 {
            width: 265px;
            font-weight: bold;
            background-color: #00FFCC;
            height: 41px;
            text-align: center;
            font-style: italic;
        }
        .auto-style78 {
            width: 1594px;
            text-align: right;
            background-color: #00FFFF;
            height: 7px;
        }
        .auto-style79 {
            width: 216px;
            font-weight: bold;
            background-color: #00FFCC;
            height: 7px;
            text-align: center;
        }
        .auto-style80 {
            width: 1594px;
            text-align: right;
            background-color: #00FFFF;
            height: 49px;
        }
        .auto-style81 {
            width: 216px;
            font-weight: bold;
            background-color: #00FFCC;
            height: 49px;
            text-align: center;
        }
        .auto-style82 {
            width: 1594px;
            text-align: right;
            background-color: #00FFFF;
            height: 59px;
        }
        .auto-style83 {
            width: 216px;
            font-weight: bold;
            background-color: #00FFCC;
            height: 59px;
            text-align: center;
        }
        .auto-style84 {
            width: 1594px;
            text-align: right;
            background-color: #00FFFF;
            height: 35px;
        }
        .auto-style85 {
            width: 216px;
            font-weight: bold;
            background-color: #00FFCC;
            height: 35px;
            text-align: center;
        }
        .auto-style86 {
            width: 1594px;
            text-align: right;
            background-color: #00FFFF;
            height: 63px;
        }
        .auto-style87 {
            width: 216px;
            font-weight: bold;
            background-color: #00FFCC;
            height: 63px;
            text-align: center;
        }
        .auto-style88 {
            width: 1594px;
            text-align: right;
            background-color: #00FFFF;
            height: 57px;
        }
        .auto-style89 {
            width: 216px;
            font-weight: bold;
            background-color: #00FFCC;
            height: 57px;
            text-align: center;
        }
        table{
            margin:0;
        }

   
    </style>
</head>
<body style="text-align: right">
    <form id="form1" runat="server">
          <h1 style="text-align: center; background-color: #669999"  dir="rtl">إدخال معلومات المريض</h1>
                    <table class="auto-style45">
                        <tr>
                            <td class="auto-style3" rowspan="7">
                             
                                    <img style="display: block; border-spacing: 0px; border-color:aqua; border-width:1px"  width="100%" height="100%" src="heartt.jpg" dir="rtl" class="auto-style49" />                      
                                </td>
                            <td class="auto-style82" colspan="2">
                                
                                <asp:RequiredFieldValidator ID="pressurevalidator0" class="input" runat="server" ControlToValidate="ageBox" ErrorMessage="يرجى ادخال العمر" style="font-size: x-small; font-style: italic; color: #FF3300"></asp:RequiredFieldValidator>
                                
                                <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="ageBox" ErrorMessage="يرجى ادخال رقم بين 1 - 150" Font-Italic="True" Font-Size="X-Small" MaximumValue="150" MinimumValue="1" SetFocusOnError="True" style="font-size: small; text-align: left" Type="Integer"></asp:RangeValidator>
   
                                <asp:TextBox ID="ageBox" class="input" runat="server" BackColor="Aqua" BorderColor="#0033CC" BorderWidth="1px" Height="25px"></asp:TextBox>
                            </td>
                            <td class="auto-style37" dir="rtl">العمر</td>
                        </tr>
                        <tr>
                            <td class="auto-style80" colspan="2"><strong>
                    <asp:DropDownList ID="DropDownList5" class="input" runat="server" DataSourceID="SqlDataSource5" DataTextField="chest_pain_type" DataValueField="chest_pain_type"  BackColor="Aqua" >
                    </asp:DropDownList>
                                </strong>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:MyProjectConnectionString %>" SelectCommand="SELECT DISTINCT [chest_pain_type] FROM ['heart dataset$']"></asp:SqlDataSource>
                            </td>
                            <td class="auto-style81" dir="rtl"><strong>نوع ألم الصدر</strong></td>
                        </tr>
                        <tr>
                            <td class="auto-style82" colspan="2">
                               &nbsp;<asp:RequiredFieldValidator ID="pressurevalidator" class="input" runat="server" ControlToValidate="prBox" ErrorMessage="يرجى ادخال الضغط" style="font-size: x-small; font-style: italic; color: #FF3300"></asp:RequiredFieldValidator>
                                
                            &nbsp;<asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="prBox" ErrorMessage="يرجى ادخال رقم بين 40 - 300" Font-Italic="True" Font-Size="X-Small" MaximumValue="300" MinimumValue="40" SetFocusOnError="True" style="font-size: small; text-align: left" Type="Integer"></asp:RangeValidator>
&nbsp;<asp:TextBox ID="prBox" class="input" runat="server" BackColor="Aqua" BorderColor="#0033CC" BorderWidth="1px" Height="25px"></asp:TextBox>
                                
                            </td>
                            <td class="auto-style83" dir="rtl">ضغط الدم الانبساطي</td>
                        </tr>
                        <tr>
                            <td class="auto-style84" colspan="2">
                                <asp:DropDownList ID="DropDownList6" class="input" runat="server" DataSourceID="SqlDataSource1" DataTextField="blood_sugar" DataValueField="blood_sugar" BackColor="Aqua">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyProjectConnectionString %>" SelectCommand="SELECT DISTINCT [blood_sugar] FROM ['heart dataset$']"></asp:SqlDataSource>
                            </td>
                            <td class="auto-style85" dir="rtl">سكر الدم</td>
                        </tr>
                        <tr>
                            <td class="auto-style78" colspan="2">
                                <asp:DropDownList ID="DropDownList7" class="input" runat="server" DataSourceID="SqlDataSource2" DataTextField="rest_electro" DataValueField="rest_electro" BackColor="Aqua">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyProjectConnectionString %>" SelectCommand="SELECT DISTINCT [rest_electro] FROM ['heart dataset$']"></asp:SqlDataSource>
                            </td>
                            <td class="auto-style79" dir="rtl">تخطيط القلب</td>
                        </tr>
                        <tr>
                            <td class="auto-style86" colspan="2">
                               
                                 <asp:RequiredFieldValidator ID="ratevalidator" class="input" runat="server" ControlToValidate="beatBox" ErrorMessage="يرجى ادخال النبض" style="font-size: x-small; font-style: italic; text-align: center; color: #FF3300"></asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                               
                                 <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="beatBox" ErrorMessage="يرجى ادخال رقم بين 30 - 250" Font-Italic="True" Font-Size="X-Small" MaximumValue="250" MinimumValue="30" SetFocusOnError="True" style="font-size: small; text-align: left" Type="Integer"></asp:RangeValidator>
                               
                                <asp:TextBox ID="beatBox" class="input" runat="server" BackColor="Aqua" BorderColor="#0033CC" BorderWidth="1px" Height="25px"></asp:TextBox>
                            </td>
                            <td class="auto-style87" dir="rtl">نبض القلب الأعظمي</td>
                        </tr>
                        <tr>
                            <td class="auto-style88" colspan="2">
                                <asp:DropDownList ID="DropDownList8" class="input" runat="server" DataSourceID="SqlDataSource3" DataTextField="exercice_angina" DataValueField="exercice_angina" BackColor="Aqua">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MyProjectConnectionString %>" SelectCommand="SELECT DISTINCT [exercice_angina] FROM ['heart dataset$']"></asp:SqlDataSource>
                            </td>
                            <td class="auto-style89" dir="rtl" style="margin:0;">ألم أثناء التمرين</td>
                        </tr>
 </table>  
                            <table class="auto-style51">
                        <tr>
                            <td class="auto-style52" dir="rtl" colspan="3">
                    <h1 style="text-align: center; background-color: #33CCCC"  dir="rtl">النتائج حسب SQL Analysis Services</h1>

                            </td>
                            </tr>
                        <tr>
                            <td class="auto-style53">

        <asp:Button ID="Button6" class="cta" runat="server" OnClick="id3" Text="ID3" style="text-align: center" />

                            </td>
                            <td class="auto-style54">

        <asp:Button ID="Button7" class="cta " runat="server" OnClick="bayes" Text="Bayes" />

                            </td>
                            <td class="auto-style55" dir="rtl">اختر خوارزمية:</td>
                        </tr>
                        <tr>
                            <td class="auto-style56">

        <asp:Label ID="Label1" runat="server" BackColor="Aqua" Font-Bold="True" Font-Size="Large" ForeColor="#000099"></asp:Label>

                            </td>
                            <td class="auto-style57">

        <asp:Label ID="Label3" runat="server" BackColor="Aqua" Font-Bold="True" Font-Size="Large" ForeColor="#000099"></asp:Label>

                            </td>
                            <td class="auto-style58" dir="rtl" rowspan="2">النتيجة:</td>
                        </tr>
                        <tr>
                            <td class="auto-style56">

        <asp:Label ID="Label9" runat="server" BackColor="Aqua" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300"></asp:Label>

                            </td>
                            <td class="auto-style57">

        <asp:Label ID="Label8" runat="server" BackColor="Aqua" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style59">

        <asp:Label ID="Label2" runat="server" Font-Size="Small"></asp:Label>


  
        
                            </td>
                            <td class="auto-style60">

        <asp:Label ID="Label4" runat="server" Font-Size="Small"></asp:Label>

                            </td>
                            <td class="auto-style61" dir="rtl">الاستعلام:</td>
                        </tr>
                        </table>
                        
    </form>
</body>
</html>
