<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<%--    <style>
        /* NOTE: The styles were added inline because Prefixfree needs access to your styles and they must be inlined if they are on local disk! */
        html {
            box-sizing: border-box;
        }

        *, *::after, *::before {
            box-sizing: inherit;
        }

            *, *:before, *:after {
                box-sizing: border-box;
                outline: none;
            }

        html {
            font-family: 'Source Sans Pro', sans-serif;
            font-size: 16px;
            font-smooth: auto;
            font-weight: 300;
            line-height: 1.5;
            color: #444;
        }

        body {
            position: relative;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            width: 100%;
            height: 100vh;
        }

        .hide {
            display: none;
        }

        .button {
            position: relative;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            width: 12.5rem;
            magrin: 0;
            padding: 1.5rem 3.125rem;
            background-color: #3498db;
            border: none;
            border-radius: 0.3125rem;
            box-shadow: 0 12px 24px 0 rgba(0, 0, 0, 0.2);
            color: white;
            font-weight: 300;
            text-transform: uppercase;
            overflow: hidden;
        }

            .button:before {
                position: absolute;
                content: '';
                bottom: 0;
                left: 0;
                width: 0%;
                height: 100%;
                background-color: #54d98c;
            }

            .button span {
                position: absolute;
                line-height: 0;
            }

                .button span i {
                    transform-origin: center center;
                }

                .button span:nth-of-type(1) {
                    top: 50%;
                    transform: translateY(-50%);
                }

                .button span:nth-of-type(2) {
                    top: 100%;
                    transform: translateY(0%);
                    font-size: 24px;
                }

                .button span:nth-of-type(3) {
                    display: none;
                }

        .active {
            background-color: #2ecc71;
        }

            .active:before {
                width: 100%;
                transition: width 3s linear;
            }

            .active span:nth-of-type(1) {
                top: -100%;
                transform: translateY(-50%);
            }

            .active span:nth-of-type(2) {
                top: 50%;
                transform: translateY(-50%);
            }

                .active span:nth-of-type(2) i {
                    animation: loading 500ms linear infinite;
                }

            .active span:nth-of-type(3) {
                display: none;
            }

        .finished {
            background-color: #54d98c;
        }

            .finished .submit {
                display: none;
            }

            .finished .loading {
                display: none;
            }

            .finished .check {
                display: block !important;
                font-size: 24px;
                animation: scale 0.5s linear;
            }

                .finished .check i {
                    transform-origin: center center;
                }

        @keyframes loading {
            100% {
                transform: rotate(360deg);
            }
        }

        @keyframes scale {
            0% {
                transform: scale(10);
            }

            50% {
                transform: scale(0.2);
            }

            70% {
                transform: scale(1.2);
            }

            90% {
                transform: scale(0.7);
            }

            100% {
                transform: scale(1);
            }
        }

    </style>--%>
    
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/style.css" />
    <script src='js/jquery.min.js'></script>
    
     <script src='https://use.fontawesome.com/2473308824.js'></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Literal ID="literal" runat="server"></asp:Literal>
            <button id="excelBut" type="button" class="button" onclick="ShowCurrentTime()">
                <span class="submit">Excel</span>
                <span class="loading"><i class="fa fa-refresh"></i></span>
                <span class="check"><i class="fa fa-check"></i></span>
            </button>
            <a href="#" id="link" style="visibility:hidden"> Скачать </a>
            <script src="js/index.js"></script>
            <script type="text/javascript">
                function ShowCurrentTime() {
                    var dataValue = '{ name: "SLava" }';
                    $.ajax({
                        type: "POST",
                        url: "Default.aspx/GetCurrentTime",
                        data: dataValue,
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                        },
                        success: OnSuccess,
                    });
                    function OnSuccess(response) {
                        //alert(response.d);
                        $("#link").attr("style", "visibility:visible");
                        $("#link").attr("href", response.d);
                    }
                }

            </script>

        </div>
    </form>
</body>
</html>
