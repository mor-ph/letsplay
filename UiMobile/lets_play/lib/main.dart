import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:lets_play/screens/home_page_screen.dart';
import 'package:lets_play/services/authentication.dart';
import 'package:lets_play/screens/auth_root_screen.dart';

void main() {
//  runApp(UserProductScreen());
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Lets Play',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
          primarySwatch: Colors.red,
          accentColor: Colors.amber,
          fontFamily: 'Quicksand',
          errorColor: Colors.red,
          canvasColor: Color.fromRGBO(227, 227, 228, 1),
          buttonColor: Color.fromRGBO(60, 71, 78, 1),
          textTheme: ThemeData.light().textTheme.copyWith(
              title: TextStyle(
                fontFamily: 'OpenSans',
                fontWeight: FontWeight.bold,
                fontSize: 18,
              ),
              button: TextStyle(color: Colors.white)),
          appBarTheme: AppBarTheme(
              textTheme: ThemeData.light().textTheme.copyWith(
                    title: TextStyle(
                        fontFamily: 'OpenSans',
                        fontSize: 20,
                        fontWeight: FontWeight.bold),
                  ),
              color: Color.fromRGBO(125, 162, 169, 1))),
      home: RootPage(auth: new Auth()),
//      home: HomePage(),
    );
  }
// This widget is the root of your application.

}
