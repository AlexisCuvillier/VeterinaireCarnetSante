import React from "react";
import "./Accueil.css";

export default function Accueil() {
  return (
    <div>
      <div class="topnav">
        <div className="flexNav">
          <a class="active" href="#home">
          Home
        </a>
        <a href="#news">News</a>
        <a href="#contact">Contact</a>
        <a href="#about">About</a>
        <a href="login">Login / Sign in</a>
        </div>
        
      </div>
      <div className="adresse">
      
        <img className="localisationLogo" src={process.env.PUBLIC_URL + `/Images/Localisation.svg`} alt="" />
        <p><a href="https://www.google.fr/maps/place/Outreau">23 RUE DE LA POUPEE QUI TOUSSE A OUTREAU (62230)</a></p>
      </div>
      <div className="img-Background"></div>
    </div>
  );
}
