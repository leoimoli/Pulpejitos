﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IngresoWF.aspx.cs" Inherits="IngresoWF" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="Sleek Dashboard - Free Bootstrap 4 Admin Dashboard Template and UI Kit. It is very powerful bootstrap admin dashboard, which allows you to build products like admin panels, content management systems and CRMs etc.">

    <title>Sign In - Sleek Admin Dashboard Template</title>

    <!-- GOOGLE FONTS -->
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,500|Poppins:400,500,600,700|Roboto:400,500" rel="stylesheet" />
    <link href="https://cdn.materialdesignicons.com/4.4.95/css/materialdesignicons.min.css" rel="stylesheet" />

    <!-- SLEEK CSS -->
    <link id="sleek-css" rel="stylesheet" href="TEMPLATE/sleek-main/theme/assets/css/sleek.css" />

    <!-- FAVICON -->
    <link href="TEMPLATE/sleek-main/theme/assets/img/favicon.png" rel="shortcut icon" />

    <!--
      HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries
    -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

    <script src="TEMPLATE/sleek-main/theme/assets/plugins/nprogress/nprogress.js"></script>
</head>

<body class="" id="body">
    <div class="container d-flex align-items-center justify-content-center vh-100">
        <div class="row justify-content-center">
            <div class="col-lg-6 col-md-10">
                <div class="card">
                    <div class="card-header bg-primary">
                        <div class="app-brand">
                            <a href="/index.html">
                                <svg class="brand-icon" xmlns="http://www.w3.org/2000/svg" preserveAspectRatio="xMidYMid" width="30" height="33"
                                    viewBox="0 0 30 33">
                                    <g fill="none" fill-rule="evenodd">
                                        <path class="logo-fill-blue" fill="#7DBCFF" d="M0 4v25l8 4V0zM22 4v25l8 4V0z" />
                                        <path class="logo-fill-white" fill="#FFF" d="M11 4v25l8 4V0z" />
                                    </g>
                                </svg>

                                <span class="brand-name">Sleek Dashboard</span>
                            </a>
                        </div>
                    </div>

                    <div class="card-body p-5">
                        <h4 class="text-dark mb-5">Sign In</h4>

                        <form runat="server">

                            <div class="row">
                                <div class="form-group col-md-12 mb-4">
                                    <input type="text" runat="server" id="txtUsuario" class="form-control input-lg" placeholder="Usuario">
                                </div>

                                <div class="form-group col-md-12 mb-4">
                                    <input type="password" runat="server" id="txtPassword" class="form-control input-lg" placeholder="Contraseña">
                                </div>

                                <div class="col-md-12 mb-4">
                                    <div class="form-group">                                      
                                        <asp:DropDownList class="form-control" ID="cmbSucursal" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="d-flex my-2 justify-content-between">
                                        <div class="d-inline-block mr-3">
                                            <label class="control control-checkbox">
                                                Recordar
                                                <input type="checkbox" />
                                                <div class="control-indicator"></div>
                                            </label>
                                        </div>

                                        <p><a class="text-blue" href="#">Recuperar contraseña?</a></p>
                                    </div>
                                    <asp:Button Text="Ingresar" runat="server" OnClick="btnIngresar_Click" CssClass="btn btn-lg btn-primary btn-block mb-4" />
                                </div>
                            </div>
                            <div class="row" id="DivMensajeError" runat="server" visible="false">
                                <div class="col-lg-12">
                                    <div class="alert alert-dismissible fade show alert-danger" role="alert">
                                        <asp:Label ID="lblMensajeError" runat="server" Text="Error"></asp:Label>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!-- <script type="module">
      import 'https://cdn.jsdelivr.net/npm/@pwabuilder/pwaupdate';

      const el = document.createElement('pwa-update');
      document.body.appendChild(el);
    </script> -->

    <!-- Javascript -->
    <script src="TEMPLATE/sleek-main/theme/assets/plugins/jquery/jquery.min.js"></script>
    <script src="TEMPLATE/sleek-main/theme/assets/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="TEMPLATE/sleek-main/theme/assets/js/sleek.js"></script>
    <link href="TEMPLATE/sleek-main/theme/assets/options/optionswitch.css" rel="stylesheet">
    <script src="TEMPLATE/sleek-main/theme/assets/options/optionswitcher.js"></script>
</body>
