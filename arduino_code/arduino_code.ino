#include <Temperature_LM75_Derived.h>
#include <LiquidCrystal_I2C.h>
#include <E4SBoard.h>
E4SClass E4SBoard;

int lcdColumns = 20;
int lcdRows = 4;
LiquidCrystal_I2C lcd(0x27, lcdColumns, lcdRows);



void setup() 
{
  // put your setup code here, to run once:
  E4SBoard.Begin();
  
  lcd.begin();
  lcd.backlight();
  
  pinMode(16, OUTPUT);
  pinMode(17, OUTPUT);
  pinMode(18, OUTPUT);
  digitalWrite(16 , LOW);
  digitalWrite(17, LOW);
  digitalWrite(18, LOW);
  Serial.begin(9600);
  lcd.clear();
}

void loop() 
{
  // put your main code here, to run repeatedly:
  if (Serial.available() > 0)
  {
    char c = Serial.read();
    if (c == '1')
    {
      lcd.clear();
      digitalWrite(16, HIGH);
      lcd.setCursor(0,0);
      lcd.print("Rood");
      digitalWrite(17, LOW);
      digitalWrite(18, LOW);
    }
    if (c == '2')
    {
      lcd.clear();
      digitalWrite(17, HIGH);
      lcd.setCursor(0,0);
      lcd.print("Blauw");
      digitalWrite(18, LOW);
      digitalWrite(16, LOW);
    }
    if (c == '3')
    {
      lcd.clear();
      digitalWrite(18, HIGH);
      lcd.setCursor(0,0);
      lcd.print("Groen");
      digitalWrite(16, LOW);
      digitalWrite(17, LOW);
    }
    if (c == '4')
    {
      lcd.clear();
      digitalWrite(16, HIGH);
      digitalWrite(17, HIGH);
      lcd.setCursor(0,0);
      lcd.print("Paars");
      digitalWrite(18, LOW);
    }
    if (c == '5')
    {
      lcd.clear();
      digitalWrite(18, HIGH);
      digitalWrite(17, HIGH);
      lcd.setCursor(0,0);
      lcd.print("Cyan");
      digitalWrite(16, LOW);
    }
    if (c == '6')
    {
      lcd.clear();
      digitalWrite(18, HIGH);
      digitalWrite(16, HIGH);
      lcd.setCursor(0,0);
      lcd.print("Geel");
      digitalWrite(17, LOW);
    }
    if (c == '7')
    {
      lcd.clear();
      digitalWrite(16, LOW);
      digitalWrite(17, LOW);
      digitalWrite(18, LOW);
      lcd.setCursor(0,0);
      lcd.print("Ongeldige Kleur");
    }
    if (c == '0')
    {
      digitalWrite(18, LOW);
      digitalWrite(16, LOW);
      digitalWrite(17, LOW);
      lcd.clear();
      lcd.setCursor(0,0);
      lcd.print("Led's Uitgeschakeld");
    }
    
  }
}
