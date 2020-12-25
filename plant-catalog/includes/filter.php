<?php
  include ("mysql_connect.php");
?>

<div id="links">
  <h3><center>Filter here:</center></h3>
  <a href="index.php">All Plants</a><br />
  <!--This is a query string-->
  <a href="index.php?displayby=plant_size&displayvalue=small">Small Plants</a><br />
  <a href="index.php?displayby=plant_size&displayvalue=medium">Medium Plants</a><br />
  <a href="index.php?displayby=plant_size&displayvalue=large">Large Plants</a><br />
  <!--Filter using MySQL BETWEEN-->
  <a href="index.php?displayby=plant_price&min=1&max=40">Plant price ($1 - $40)</a><br />
  <a href="index.php?displayby=plant_price&min=41&max=100">Plant price ($41 - $100)</a><br />
</div>

