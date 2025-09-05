# insights_service/app.py
from fastapi import FastAPI
app = FastAPI()
@app.post("/insights")
def get_insights(data: dict):
  # TODO: apply static rules
  return {"insights": []}
