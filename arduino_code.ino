#include <E4SBoard.h>
E4SClass E4SBoard;

void setup() 
{
  // put your setup code here, to run once:
  E4SBoard.Begin();
  pinMode(2, OUTPUT);
  pinMode(16, OUTPUT);
  pinMode(17, OUTPUT);
  digitalWrite(2 , LOW);
  digitalWrite(16, LOW);
  digitalWrite(17, LOW);
  Serial.begin(9600);
}

void loop() 
{
  // put your main code here, to run repeatedly:
  if (Serial.available() > 0)
  {
    char c = Serial.read();
    if (c == '1')
    {
      digitalWrite(2, HIGH);
    }
    if (c == '2')
    {
      digitalWrite(16, HIGH);
    }
    if (c == '3')
    {
      digitalWrite(17, HIGH);
    }
    else if (c == '0')
    {
      digitalWrite(2, LOW);
      digitalWrite(16, LOW);
      digitalWrite(17, LOW);
    }
    
  }
}
